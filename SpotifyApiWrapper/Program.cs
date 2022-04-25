using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SpotifyApiWrapper.Authentication;
using SpotifyApiWrapper.Managers;
using SpotifyApiWrapper.Managers.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = configuration.GetSection("Auth:Authority").Get<string>();
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

builder.Services.AddControllers(opt => { opt.Filters.Add(new AuthorizeFilter()); });
builder.Services.AddSwaggerGen(options =>
{
    var scheme = new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri(configuration.GetSection("Auth:Swagger:AuthorizationUrl").Get<string>()),
                TokenUrl = new Uri(configuration.GetSection("Auth:Swagger:TokenUrl").Get<string>())
            }
        },
        Type = SecuritySchemeType.OAuth2
    };

    options.AddSecurityDefinition("OAuth", scheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Id = "OAuth", Type = ReferenceType.SecurityScheme }
            },
            new List<string> { }
        }
    });
});



builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();


builder.Services.AddScoped<IAlbumManager, AlbumManager>();
builder.Services.AddScoped<ITokenManager, TokenManager>();
builder.Services.AddScoped<IClientCredentials, ClientCredentials>();
builder.Services.AddScoped<IArtistManager, ArtistManager>();
builder.Services.AddScoped<ITrackManager, TrackManager>();
builder.Services.AddScoped<IBrowseManager, BrowseManager>();
builder.Services.AddScoped<IFollowManager, FollowManager>();
builder.Services.AddScoped<IAuthorizationManager, AuthorizationManager>();


var app = builder.Build();

app.UseStaticFiles();


app.UseSwagger()
     .UseSwaggerUI(options =>
     {
         //options.EnablePersistAuthorization();
         options.SwaggerEndpoint("/swagger/v1/swagger.json", "SpotifyApiWrapper");
         options.OAuthClientId("api-swagger");
         options.OAuthClientSecret("api-swagger");
         options.OAuth2RedirectUrl("https://localhost:44344/swagger/oauth2-redirect.html");
         options.OAuthScopes("user-follow-read", "user-follow-modify");
         options.OAuthUsePkce();
         options.InjectStylesheet("/content/swagger-extras.css");
     });



app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
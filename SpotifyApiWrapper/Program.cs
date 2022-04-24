
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SpotifyApiWrapper.Authentication;
using SpotifyApiWrapper.Entities;
using SpotifyApiWrapper.Managers;
using SpotifyApiWrapper.Managers.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpotifyApi", Version = "v1" });
    c.OperationFilter<AuthorizeOperationFilter>();
    //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    //{
    //    Type = SecuritySchemeType.OAuth2,
    //    Flows = new OpenApiOAuthFlows
    //    {
    //        Implicit = new OpenApiOAuthFlow
    //        {
    //            AuthorizationUrl = SpotifyUrls.Authorize,
    //            TokenUrl = SpotifyUrls.OAuthToken,
    //            Scopes = new Dictionary<string, string>
    //                        {
    //                            { "user-follow-read", "user-follow-read" },
    //                            { "writeAccess", "Access write operations" }
    //                        }
    //        }
    //    }
    //});


    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);
});

builder.Services.AddAuthentication();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spotify Api V1");
        c.OAuthClientId("cleint-id");
        c.OAuthAppName("OAuth-app");
        c.OAuthScopeSeparator(" ");
        c.OAuthUsePkce();
    });    
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapControllers();

app.Run();

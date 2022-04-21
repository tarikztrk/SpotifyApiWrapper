
using SpotifyApiWrapper.Authentication;
using SpotifyApiWrapper.Managers;
using SpotifyApiWrapper.Managers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

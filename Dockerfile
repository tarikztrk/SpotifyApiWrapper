FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 80
EXPOSE 44344

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SpotifyApiWrapper/SpotifyApiWrapper.csproj", "SpotifyApiWrapper/"]
RUN dotnet restore "SpotifyApiWrapper/SpotifyApiWrapper.csproj"
COPY . .
WORKDIR "/src/SpotifyApiWrapper"
RUN dotnet build "SpotifyApiWrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpotifyApiWrapper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpotifyApiWrapper.dll"]
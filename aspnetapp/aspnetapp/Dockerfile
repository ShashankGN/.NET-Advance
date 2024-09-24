FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["aspnetapp.csproj", ""]
RUN dotnet restore "./aspnetapp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "aspnetapp.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "aspnetapp.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
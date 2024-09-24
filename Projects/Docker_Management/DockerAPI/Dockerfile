

# //FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build  ->it means that from the microsoft registery download the specified verion 

# //WORKDIR /home/app  ->inside the container all the applications should go inside the specified path
# //COPY ApiDocker.csproj ./ApiDocker/  -> . stands for app folder
# //above line will copy the file inside ApiDocker.csproj inside the ApiDocker folder
# //RUN dotnet restore ./ApiDocker/  ->to install the dependencies required by reading the .csproj file
# //dependencies will be imside the .csproj file
# //COPY . .  ->first . is source that is the root second . is the destination
# //from the root directory that is where the projectsetup is there,all the files from there are copied to the ApiDocker folder inside the container
# //RUN dotnet publish ./ApiDocker .csproj -o /publish/  ->it will build the application in release mode and whatever the output is there like the .dll files put it into the publish folder
# //WORKDIR /publish  ->now the working directory will be publish
# //ENV ASPNETCORE_URLS="http://0.0.0.0:5000"  ->environmemt variable
# //ENTRYPOINT ["dotnet","ApiDocker.dll"]  ->entrypoint of the applocation will be this,in background it will run the command dotnet run ApiDocker.dll


# //docker build -t 



# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# WORKDIR /home/app
# COPY DockerAPI.csproj ./DockerAPI/
# RUN dotnet restore ./DockerAPI/
# COPY . .
# RUN dotnet publish ./DockerAPI.csproj -o /publish/
# WORKDIR /publish
# ENV ASPNETCORE_URLS="http://0.0.0.0:5000"
# ENTRYPOINT ["dotnet","DockerAPI.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DockerAPI.csproj", "."]
RUN dotnet restore "./DockerAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DockerAPI.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "DockerAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "DockerAPI.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DeveloperInfo.API/DeveloperInfo.API.csproj", "DeveloperInfo.API/"]
RUN dotnet restore "DeveloperInfo.API/DeveloperInfo.API.csproj"
COPY . .
WORKDIR "/src/DeveloperInfo.API"
RUN dotnet build "DeveloperInfo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeveloperInfo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeveloperInfo.API.dll"]
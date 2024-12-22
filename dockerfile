FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

EXPOSE 80
ENV LANG=C.UTF-8
ENV LC_ALL=C.UTF-8
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /FumLabAPI

COPY ["FumLabAPI/FumLabAPI.csproj", "FumLabAPI/"]
COPY ["BusinessLogic/BusinessLogic.csproj", "BusinessLogic/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
RUN dotnet restore "FumLabAPI/FumLabAPI.csproj"

COPY . .
FROM build AS publish
RUN dotnet publish "FumLabAPI/FumLabAPI.csproj" -c Release -o /app/publish /p:UserAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
COPY ./FumLabAPI/appsettings.json /app/appsettings.json

ENTRYPOINT ["dotnet", "FumLabAPI.dll"]
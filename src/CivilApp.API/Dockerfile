#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./CivilApp.API/CivilApp.API.csproj ./
COPY ./CivilApp.Core/CivilApp.Core.csproj ./
COPY ./CivilApp.Infrastructure/CivilApp.Infrastructure.csproj ./

RUN dotnet restore "CivilApp.API.csproj"
COPY . .
WORKDIR "/src/src/CivilApp.API"
RUN dotnet build "CivilApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CivilApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CivilApp.API.dll"]

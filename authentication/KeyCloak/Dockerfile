#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["KeyCloak/KeyCloak.csproj", "KeyCloak/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "KeyCloak/KeyCloak.csproj"
COPY . .
WORKDIR "/src/KeyCloak"
RUN dotnet build "KeyCloak.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KeyCloak.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KeyCloak.dll"]
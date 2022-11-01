# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebUI/WebUI.csproj","WebUI/"]
COPY ["Application/Application.csproj","Application/"]
COPY ["Domain/Domain.csproj","Domain/"]
COPY ["Infrastructure/Infrastructure.csproj","Infrastructure/"]
RUN dotnet restore "WebUI/WebUI.csproj"
COPY . .
#WORKDIR "/src/WebUI"
RUN dotnet build "WebUI/WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebUI/WebUI.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebUI.dll"]
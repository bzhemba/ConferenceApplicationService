﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ConferenceApplicationSystem/ConferenceApplicationSystem.csproj", "src/ConferenceApplicationSystem/"]
RUN dotnet restore "src/ConferenceApplicationSystem/ConferenceApplicationSystem.csproj"
COPY . .
WORKDIR "/src/src/ConferenceApplicationSystem"
RUN dotnet build "ConferenceApplicationSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConferenceApplicationSystem.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConferenceApplicationSystem.dll"]

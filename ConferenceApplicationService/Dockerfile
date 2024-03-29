FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ConferenceApplicationService/ConferenceApplicationService.csproj", "ConferenceApplicationService/"]
RUN dotnet restore "ConferenceApplicationService/ConferenceApplicationService.csproj"
COPY . .
WORKDIR "/src/ConferenceApplicationService"
RUN dotnet build "ConferenceApplicationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConferenceApplicationService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConferenceApplicationService.dll"]

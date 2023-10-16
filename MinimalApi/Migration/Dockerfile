FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["migration/migration.csproj", "migration/"]
RUN dotnet restore "migration/migration.csproj"
COPY . .
WORKDIR "/src/migration"
RUN dotnet build "migration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "migration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "migration.dll"]

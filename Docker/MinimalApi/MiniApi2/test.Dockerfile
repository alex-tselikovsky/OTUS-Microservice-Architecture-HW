FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

 
COPY *.csproj ./
 
RUN dotnet restore
 
COPY . ./
 
RUN dotnet publish -c Release -o out
 
FROM mcr.microsoft.com/dotnet/aspnet:5.0
 
WORKDIR /app
 
COPY --from=build-env /app/out .
 
ENTRYPOINT ["dotnet", "MyProject.dll"]
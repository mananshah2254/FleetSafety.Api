# ---------- BUILD STAGE ----------
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    WORKDIR /src
    
    # Copy everything and restore
    COPY . .
    RUN dotnet restore
    
    # Publish in Release mode
    RUN dotnet publish -c Release -o /app/publish
    
    # ---------- RUNTIME STAGE ----------
    FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
    WORKDIR /app
    
    COPY --from=build /app/publish .
    
    # App will listen on port 8080 inside the container
    ENV ASPNETCORE_URLS=http://+:8080
    EXPOSE 8080
    
    ENTRYPOINT ["dotnet", "FleetSafety.Api.dll"]
    
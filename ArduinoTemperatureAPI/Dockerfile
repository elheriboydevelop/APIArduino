# Imagen base para la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 5150

ENV ASPNETCORE_URLS=http://+:5150

# Imagen para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG configuration=Release
WORKDIR /src
COPY ["ArduinoTemperatureAPI.csproj", "./"]
RUN dotnet restore "ArduinoTemperatureAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ArduinoTemperatureAPI.csproj" -c $configuration -o /app/build

# Publicación de la aplicación
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ArduinoTemperatureAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Imagen final de ejecución
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArduinoTemperatureAPI.dll"]

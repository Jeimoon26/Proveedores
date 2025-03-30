# Imagen base de .NET 6 para compilación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar archivos del proyecto
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Imagen base para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto en el que corre la API
EXPOSE 5000
EXPOSE 5001

# Comando para ejecutar la API
ENTRYPOINT ["dotnet", "ProveedoresAPI.dll"]

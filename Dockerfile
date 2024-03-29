#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["Monitoring/Monitoring.csproj", "Monitoring/"]
#RUN dotnet restore "Monitoring/Monitoring.csproj"
#COPY . .
#WORKDIR "/src/Monitoring"
#RUN dotnet build "Monitoring.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "Monitoring.csproj" -c Release -o /app/publish /p:UseAppHost=false

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Monitoring.dll"]

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore "./Monitoring.csproj"
# Build and publish a release
RUN dotnet publish "Monitoring.csproj" -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Monitoring.dll"]






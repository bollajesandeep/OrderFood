#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["FoodOrder1.csproj", "FoodOrder1/"]
RUN dotnet restore "FoodOrder1/FoodOrder1.csproj"
COPY . .
WORKDIR "/src/FoodOrder1"
RUN dotnet build "FoodOrder1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodOrder1.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodOrder1.dll"]
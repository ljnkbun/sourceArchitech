#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/business/material/Shopfloor.Material.Api/Shopfloor.Material.Api.csproj", "src/services/business/material/Shopfloor.Material.Api/"]
COPY ["src/services/business/material/Shopfloor.Material.Infrastructure/Shopfloor.Material.Infrastructure.csproj", "src/services/business/material/Shopfloor.Material.Infrastructure/"]
COPY ["src/shareds/Shopfloor.Core/Shopfloor.Core.csproj", "src/shareds/Shopfloor.Core/"]
COPY ["src/services/business/material/Shopfloor.Material.Application/Shopfloor.Material.Application.csproj", "src/services/business/material/Shopfloor.Material.Application/"]
COPY ["src/shareds/Shopfloor.Cache/Shopfloor.Cache.csproj", "src/shareds/Shopfloor.Cache/"]
COPY ["src/shareds/Shopfloor.EventBus/Shopfloor.EventBus.csproj", "src/shareds/Shopfloor.EventBus/"]
COPY ["src/services/business/material/Shopfloor.Material.Domain/Shopfloor.Material.Domain.csproj", "src/services/business/material/Shopfloor.Material.Domain/"]
RUN dotnet restore "src/services/business/material/Shopfloor.Material.Api/Shopfloor.Material.Api.csproj"
COPY . .
WORKDIR "/src/src/services/business/material/Shopfloor.Material.Api"
RUN dotnet build "Shopfloor.Material.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopfloor.Material.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopfloor.Material.Api.dll"]
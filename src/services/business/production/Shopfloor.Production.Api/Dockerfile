#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/business/production/Shopfloor.Production.Api/Shopfloor.Production.Api.csproj", "src/services/business/production/Shopfloor.Production.Api/"]
COPY ["src/services/business/production/Shopfloor.Production.Infrastructure/Shopfloor.Production.Infrastructure.csproj", "src/services/business/production/Shopfloor.Production.Infrastructure/"]
COPY ["src/services/business/production/Shopfloor.Production.Application/Shopfloor.Production.Application.csproj", "src/services/business/production/Shopfloor.Production.Application/"]
COPY ["src/shareds/Shopfloor.Cache/Shopfloor.Cache.csproj", "src/shareds/Shopfloor.Cache/"]
COPY ["src/shareds/Shopfloor.EventBus/Shopfloor.EventBus.csproj", "src/shareds/Shopfloor.EventBus/"]
COPY ["src/services/business/production/Shopfloor.Production.Domain/Shopfloor.Production.Domain.csproj", "src/services/business/production/Shopfloor.Production.Domain/"]
COPY ["src/shareds/Shopfloor.Core/Shopfloor.Core.csproj", "src/shareds/Shopfloor.Core/"]
RUN dotnet restore "src/services/business/production/Shopfloor.Production.Api/Shopfloor.Production.Api.csproj"
COPY . .
WORKDIR "/src/src/services/business/production/Shopfloor.Production.Api"
RUN dotnet build "Shopfloor.Production.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopfloor.Production.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopfloor.Production.Api.dll"]
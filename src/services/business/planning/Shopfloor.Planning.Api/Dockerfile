#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/business/planning/Shopfloor.Planning.Api/Shopfloor.Planning.Api.csproj", "src/services/business/planning/Shopfloor.Planning.Api/"]
COPY ["src/services/business/planning/Shopfloor.Planning.Infrastructure/Shopfloor.Planning.Infrastructure.csproj", "src/services/business/planning/Shopfloor.Planning.Infrastructure/"]
COPY ["src/services/business/planning/Shopfloor.Planning.Application/Shopfloor.Planning.Application.csproj", "src/services/business/planning/Shopfloor.Planning.Application/"]
COPY ["src/shareds/Shopfloor.Cache/Shopfloor.Cache.csproj", "src/shareds/Shopfloor.Cache/"]
COPY ["src/shareds/Shopfloor.EventBus/Shopfloor.EventBus.csproj", "src/shareds/Shopfloor.EventBus/"]
COPY ["src/services/business/planning/Shopfloor.Planning.Domain/Shopfloor.Planning.Domain.csproj", "src/services/business/planning/Shopfloor.Planning.Domain/"]
COPY ["src/shareds/Shopfloor.Core/Shopfloor.Core.csproj", "src/shareds/Shopfloor.Core/"]
RUN dotnet restore "src/services/business/planning/Shopfloor.Planning.Api/Shopfloor.Planning.Api.csproj"
COPY . .
WORKDIR "/src/src/services/business/planning/Shopfloor.Planning.Api"
RUN dotnet build "Shopfloor.Planning.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopfloor.Planning.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopfloor.Planning.Api.dll"]
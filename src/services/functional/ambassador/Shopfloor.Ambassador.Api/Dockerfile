#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/functional/ambassador/Shopfloor.Ambassador.Api/Shopfloor.Ambassador.Api.csproj", "src/services/functional/ambassador/Shopfloor.Ambassador.Api/"]
COPY ["src/services/functional/ambassador/Shopfloor.Ambassador.Infrastructure/Shopfloor.Ambassador.Infrastructure.csproj", "src/services/functional/ambassador/Shopfloor.Ambassador.Infrastructure/"]
COPY ["src/services/functional/ambassador/Shopfloor.Ambassador.Application/Shopfloor.Ambassador.Application.csproj", "src/services/functional/ambassador/Shopfloor.Ambassador.Application/"]
COPY ["src/shareds/Shopfloor.Cache/Shopfloor.Cache.csproj", "src/shareds/Shopfloor.Cache/"]
COPY ["src/shareds/Shopfloor.EventBus/Shopfloor.EventBus.csproj", "src/shareds/Shopfloor.EventBus/"]
COPY ["src/services/functional/ambassador/Shopfloor.Ambassador.Domain/Shopfloor.Ambassador.Domain.csproj", "src/services/functional/ambassador/Shopfloor.Ambassador.Domain/"]
COPY ["src/shareds/Shopfloor.Core/Shopfloor.Core.csproj", "src/shareds/Shopfloor.Core/"]
RUN dotnet restore "src/services/functional/ambassador/Shopfloor.Ambassador.Api/Shopfloor.Ambassador.Api.csproj"
COPY . .
WORKDIR "/src/src/services/functional/ambassador/Shopfloor.Ambassador.Api"
RUN dotnet build "Shopfloor.Ambassador.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopfloor.Ambassador.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopfloor.Ambassador.Api.dll"]
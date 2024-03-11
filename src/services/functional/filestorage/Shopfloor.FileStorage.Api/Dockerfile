#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/functional/filestorage/Shopfloor.FileStorage.Api/Shopfloor.FileStorage.Api.csproj", "src/services/functional/filestorage/Shopfloor.FileStorage.Api/"]
COPY ["src/services/functional/filestorage/Shopfloor.FileStorage.Infrastructure/Shopfloor.FileStorage.Infrastructure.csproj", "src/services/functional/filestorage/Shopfloor.FileStorage.Infrastructure/"]
COPY ["src/services/functional/filestorage/Shopfloor.FileStorage.Application/Shopfloor.FileStorage.Application.csproj", "src/services/functional/filestorage/Shopfloor.FileStorage.Application/"]
COPY ["src/shareds/Shopfloor.Cache/Shopfloor.Cache.csproj", "src/shareds/Shopfloor.Cache/"]
COPY ["src/shareds/Shopfloor.EventBus/Shopfloor.EventBus.csproj", "src/shareds/Shopfloor.EventBus/"]
COPY ["src/services/functional/filestorage/Shopfloor.FileStorage.Domain/Shopfloor.FileStorage.Domain.csproj", "src/services/functional/filestorage/Shopfloor.FileStorage.Domain/"]
COPY ["src/shareds/Shopfloor.Core/Shopfloor.Core.csproj", "src/shareds/Shopfloor.Core/"]
RUN dotnet restore "src/services/functional/filestorage/Shopfloor.FileStorage.Api/Shopfloor.FileStorage.Api.csproj"
COPY . .
WORKDIR "/src/src/services/functional/filestorage/Shopfloor.FileStorage.Api"
RUN dotnet build "Shopfloor.FileStorage.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopfloor.FileStorage.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopfloor.FileStorage.Api.dll"]
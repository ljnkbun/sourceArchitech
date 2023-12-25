#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/business/barcode/Shopfloor.Barcode.Api/Shopfloor.Barcode.Api.csproj", "src/services/business/barcode/Shopfloor.Barcode.Api/"]
COPY ["src/services/business/barcode/Shopfloor.Barcode.Infrastructure/Shopfloor.Barcode.Infrastructure.csproj", "src/services/business/barcode/Shopfloor.Barcode.Infrastructure/"]
COPY ["src/shareds/Shopfloor.Core/Shopfloor.Core.csproj", "src/shareds/Shopfloor.Core/"]
COPY ["src/services/business/barcode/Shopfloor.Barcode.Application/Shopfloor.Barcode.Application.csproj", "src/services/business/barcode/Shopfloor.Barcode.Application/"]
COPY ["src/shareds/Shopfloor.Cache/Shopfloor.Cache.csproj", "src/shareds/Shopfloor.Cache/"]
COPY ["src/shareds/Shopfloor.EventBus/Shopfloor.EventBus.csproj", "src/shareds/Shopfloor.EventBus/"]
COPY ["src/services/business/barcode/Shopfloor.Barcode.Domain/Shopfloor.Barcode.Domain.csproj", "src/services/business/barcode/Shopfloor.Barcode.Domain/"]
RUN dotnet restore "src/services/business/barcode/Shopfloor.Barcode.Api/Shopfloor.Barcode.Api.csproj"
COPY . .
WORKDIR "/src/src/services/business/barcode/Shopfloor.Barcode.Api"
RUN dotnet build "Shopfloor.Barcode.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopfloor.Barcode.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopfloor.Barcode.Api.dll"]
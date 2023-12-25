#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/services/functional/notification/Shopfloor.Notification/Shopfloor.Notification.csproj", "src/services/functional/notification/Shopfloor.Notification/"]
COPY ["src/shareds/Shopfloor.Core/Shopfloor.Core.csproj", "src/shareds/Shopfloor.Core/"]
COPY ["src/shareds/Shopfloor.EventBus/Shopfloor.EventBus.csproj", "src/shareds/Shopfloor.EventBus/"]
RUN dotnet restore "src/services/functional/notification/Shopfloor.Notification/Shopfloor.Notification.csproj"
COPY . .
WORKDIR "/src/src/services/functional/notification/Shopfloor.Notification"
RUN dotnet build "Shopfloor.Notification.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopfloor.Notification.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopfloor.Notification.dll"]
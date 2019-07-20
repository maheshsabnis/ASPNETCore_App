FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CoreAppHome/CoreAppHome.csproj", "CoreAppHome/"]
RUN dotnet restore "CoreAppHome/CoreAppHome.csproj"
COPY . .
WORKDIR "/src/CoreAppHome"
RUN dotnet build "CoreAppHome.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CoreAppHome.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreAppHome.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim-arm64v8 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["HVK_ZZTop/HVK_ZZTop.csproj", "HVK_ZZTop/"]
RUN dotnet restore "HVK_ZZTop/HVK_ZZTop.csproj"
COPY . .
WORKDIR "/src/HVK_ZZTop"
RUN dotnet build "HVK_ZZTop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HVK_ZZTop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HVK_ZZTop.dll"]
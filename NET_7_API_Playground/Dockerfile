#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NET_7_API_Playground/NET_7_API_Playground.csproj", "NET_7_API_Playground/"]
RUN dotnet restore "NET_7_API_Playground/NET_7_API_Playground.csproj"
COPY . .
WORKDIR "/src/NET_7_API_Playground"
RUN dotnet build "NET_7_API_Playground.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NET_7_API_Playground.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NET_7_API_Playground.dll"]
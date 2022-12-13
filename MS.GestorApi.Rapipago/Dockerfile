#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MS.GestorApi.Rapipago/MS.GestorApi.Rapipago.csproj", "MS.GestorApi.Rapipago/"]
RUN dotnet restore "MS.GestorApi.Rapipago/MS.GestorApi.Rapipago.csproj"
COPY . .
WORKDIR "/src/MS.GestorApi.Rapipago"
RUN dotnet build "MS.GestorApi.Rapipago.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MS.GestorApi.Rapipago.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MS.GestorApi.Rapipago.dll"]
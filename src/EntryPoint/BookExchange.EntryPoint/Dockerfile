FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/EntryPoint/BookExchange.EntryPoint/BookExchange.EntryPoint.csproj", "src/EntryPoint/BookExchange.EntryPoint/"]
RUN dotnet restore "src/EntryPoint/BookExchange.EntryPoint/BookExchange.EntryPoint.csproj"
COPY . .
WORKDIR "/src/src/EntryPoint/BookExchange.EntryPoint"
RUN dotnet build "BookExchange.EntryPoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookExchange.EntryPoint.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookExchange.EntryPoint.dll"]

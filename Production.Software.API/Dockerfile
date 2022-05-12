FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Production.Software.API/Production.Software.API.csproj", "Production.Software.API/"]
RUN dotnet restore "Production.Software.API/Production.Software.API.csproj"
COPY . .
WORKDIR "/src/Production.Software.API"
RUN dotnet build "Production.Software.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Production.Software.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Production.Software.API.dll"]

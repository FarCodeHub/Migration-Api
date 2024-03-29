#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Migration.csproj", "."]
COPY ["../Infrastracture/Infrastracture.csproj", "../Infrastracture/"]
COPY ["../Application/Application.csproj", "../Application/"]
COPY ["../Domain/Domain.csproj", "../Domain/"]
COPY ["../Persistence/Persistence.csproj", "../Persistence/"]
RUN dotnet restore "Migration.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Migration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Migration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Migration.dll"]

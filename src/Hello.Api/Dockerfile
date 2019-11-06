FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
ENV RestoreUseSkipNonexistentTargets false
WORKDIR /src
COPY Hello.Api.sln ./
COPY Hello.Api/Hello.Api.csproj Hello.Api/
RUN dotnet restore
COPY . .
WORKDIR /src/Hello.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Hello.Api.dll"]

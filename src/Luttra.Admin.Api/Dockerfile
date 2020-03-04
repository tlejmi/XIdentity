FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Luttra.Admin.Api/Luttra.Admin.Api.csproj", "src/Luttra.Admin.Api/"]
COPY ["src/Luttra.Admin.EntityFramework.Shared/Luttra.Admin.EntityFramework.Shared.csproj", "src/Luttra.Admin.EntityFramework.Shared/"]
COPY ["src/Luttra.Admin.EntityFramework.SqlServer/Luttra.Admin.EntityFramework.SqlServer.csproj", "src/Luttra.Admin.EntityFramework.SqlServer/"]
COPY ["src/Luttra.Admin.EntityFramework.PostgreSQL/Luttra.Admin.EntityFramework.PostgreSQL.csproj", "src/Luttra.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/Luttra.Admin.EntityFramework.MySql/Luttra.Admin.EntityFramework.MySql.csproj", "src/Luttra.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/Luttra.Admin.Api/Luttra.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/Luttra.Admin.Api"
RUN dotnet build "Luttra.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Luttra.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Luttra.Admin.Api.dll"]
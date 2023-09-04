FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/Movie.Web.Host/Movie.Web.Host.csproj", "src/Movie.Web.Host/"]
COPY ["src/Movie.Web.Core/Movie.Web.Core.csproj", "src/Movie.Web.Core/"]
COPY ["src/Movie.Application/Movie.Application.csproj", "src/Movie.Application/"]
COPY ["src/Movie.Core/Movie.Core.csproj", "src/Movie.Core/"]
COPY ["src/Movie.EntityFrameworkCore/Movie.EntityFrameworkCore.csproj", "src/Movie.EntityFrameworkCore/"]
WORKDIR "/src/src/Movie.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Movie.Web.Host", "src/Movie.Web.Host"]
COPY ["src/Movie.Web.Core", "src/Movie.Web.Core"]
COPY ["src/Movie.Application", "src/Movie.Application"]
COPY ["src/Movie.Core", "src/Movie.Core"]
COPY ["src/Movie.EntityFrameworkCore", "src/Movie.EntityFrameworkCore"]
WORKDIR "/src/src/Movie.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Movie.Web.Host.dll"]

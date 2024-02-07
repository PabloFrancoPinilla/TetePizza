FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build


WORKDIR /app


COPY *.sln .
COPY Api/*.csproj ./Api/
COPY Data/*.csproj ./Data/
COPY Models/*.csproj ./Models/
COPY Service/*.csproj ./Service/
RUN dotnet restore TetePizza.sln


COPY . .
RUN dotnet publish TetePizza.sln -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./


EXPOSE 80


ENTRYPOINT ["dotnet", "TetePizza.Api.dll"]

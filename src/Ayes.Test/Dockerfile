FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY Ayes.Test.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish "Ayes.Test.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Ayes.Test.dll"]

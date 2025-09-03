# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./src/RcbcRequests/RcbcRequests.csproj ./src/RcbcRequests/
RUN dotnet restore ./src/RcbcRequests/RcbcRequests.csproj
COPY ./src/RcbcRequests ./src/RcbcRequests
WORKDIR /src/src/RcbcRequests
RUN dotnet publish -c Release -o /app

# Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet","RcbcRequests.dll"]

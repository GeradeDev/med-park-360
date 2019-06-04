FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MedPark.API.Gateway/MedPark.API.Gateway.csproj", "MedPark.API.Gateway/"]
COPY ["MedPark.Common/MedPark.Common.csproj", "MedPark.Common/"]
RUN dotnet restore "MedPark.API.Gateway/MedPark.API.Gateway.csproj"
COPY . .
WORKDIR "/src/MedPark.API.Gateway"
RUN dotnet build "MedPark.API.Gateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MedPark.API.Gateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5000
ENTRYPOINT ["dotnet", "MedPark.API.Gateway.dll"]
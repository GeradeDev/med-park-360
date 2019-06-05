FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MedPark.Identity/MedPark.Identity.csproj", "MedPark.Identity/"]
COPY ["MedPark.Common/MedPark.Common.csproj", "MedPark.Common/"]
RUN dotnet restore "MedPark.Identity/MedPark.Identity.csproj"
COPY . .
WORKDIR "/src/MedPark.Identity"
RUN dotnet build "MedPark.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MedPark.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5001
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5001
EXPOSE 1433 
ENTRYPOINT ["dotnet", "MedPark.Identity.dll"]
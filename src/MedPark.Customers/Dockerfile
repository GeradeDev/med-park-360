FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MedPark.Customers/MedPark.CustomersService.csproj", "MedPark.Customers/"]
COPY ["MedPark.Common/MedPark.Common.csproj", "MedPark.Common/"]
RUN dotnet restore "MedPark.Customers/MedPark.CustomersService.csproj"
COPY . .
WORKDIR "/src/MedPark.Customers"
RUN dotnet build "MedPark.CustomersService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MedPark.CustomersService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS http://*:5002
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 5002
ENTRYPOINT ["dotnet", "MedPark.CustomersService.dll"]
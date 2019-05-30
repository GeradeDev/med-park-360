FROM microsoft/dotnet:2.2-sdk as build
WORKDIR /app

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish --output /out/ --configuration Release


FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "MedPark.API.Gateway.dll"]
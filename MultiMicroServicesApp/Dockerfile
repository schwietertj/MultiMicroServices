FROM microsoft/dotnet AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY MultiMicroServicesApp/MultiMicroServicesApp.csproj MultiMicroServicesApp/
RUN dotnet restore MultiMicroServicesApp/MultiMicroServicesApp.csproj
COPY . .
WORKDIR /src/MultiMicroServicesApp
RUN dotnet build MultiMicroServicesApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MultiMicroServicesApp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ["dotnet", "MultiMicroServicesApp.dll"]

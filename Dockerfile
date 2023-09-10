FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-stage
WORKDIR /app
COPY src/NamiSic.Api/NamiSic.Api.csproj ./NamiSic.Api/NamiSic.Api.csproj
COPY src/NamiSic.Domain/NamiSic.Domain.csproj ./NamiSic.Domain/NamiSic.Domain.csproj
COPY src/NamiSic.sln ./NamiSic.sln
RUN dotnet restore ./NamiSic.Api/NamiSic.Api.csproj
COPY src .
RUN dotnet publish ./NamiSic.Api/NamiSic.Api.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime-stage
WORKDIR /publish
COPY --from=build-stage /publish .
EXPOSE 80 443
ENTRYPOINT ["dotnet", "NamiSic.Api.dll"]

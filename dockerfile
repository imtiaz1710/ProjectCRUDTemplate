FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
Copy *.sln .
COPY ProjectCRUDTemplate.API/*.csproj ./ProjectCRUDTemplate.API/
COPY ProjectCRUDTemplate.Infrustructure/*.csproj ./ProjectCRUDTemplate.Infrustructure/
COPY ProjectCRUDTemplate.Core/*.csproj ./ProjectCRUDTemplate.Core/
COPY ProjectCRUDTemplate.Application/*.csproj ./ProjectCRUDTemplate.Application/

# Restore as distinct layers
RUN dotnet restore
COPY ProjectCRUDTemplate.API/. ./ProjectCRUDTemplate.API/
COPY ProjectCRUDTemplate.Infrustructure/. ./ProjectCRUDTemplate.Infrustructure/
COPY ProjectCRUDTemplate.Core/. ./ProjectCRUDTemplate.Core/
COPY ProjectCRUDTemplate.Application/. ./ProjectCRUDTemplate.Application/
WORKDIR /App/ProjectCRUDTemplate.API
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/ProjectCRUDTemplate.API/out .
ENTRYPOINT ["dotnet", "ProjectCRUDTemplate.API.dll"]
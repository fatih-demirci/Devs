# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/corePackages/Core.Application/*.csproj ./src/corePackages/Core.Application/
COPY src/corePackages/Core.CrossCuttingConcerns/*.csproj ./src/corePackages/Core.CrossCuttingConcerns/
COPY src/corePackages/Core.Persistence/*.csproj ./src/corePackages/Core.Persistence/
COPY src/corePackages/Core.Security/*.csproj ./src/corePackages/Core.Security/

COPY src/projects/kodlama.io/Core/Devs.Application/*.csproj ./src/projects/kodlama.io/Core/Devs.Application/
COPY src/projects/kodlama.io/Core/Devs.Domain/*.csproj ./src/projects/kodlama.io/Core/Devs.Domain/
COPY src/projects/kodlama.io/Infrastructure/Devs.Infrastructure/*.csproj ./src/projects/kodlama.io/Infrastructure/Devs.Infrastructure/
COPY src/projects/kodlama.io/Infrastructure/Devs.Persistence/*.csproj ./src/projects/kodlama.io/Infrastructure/Devs.Persistence/
COPY src/projects/kodlama.io/Presentation/Devs.WebAPI/*.csproj ./src/projects/kodlama.io/Presentation/Devs.WebAPI/

RUN dotnet restore

# copy everything else and build app
COPY src/corePackages/Core.Application/. ./src/corePackages/Core.Application/
COPY src/corePackages/Core.CrossCuttingConcerns/. ./src/corePackages/Core.CrossCuttingConcerns/
COPY src/corePackages/Core.Persistence/. ./src/corePackages/Core.Persistence/
COPY src/corePackages/Core.Security/. ./src/corePackages/Core.Security/

COPY src/projects/kodlama.io/Core/Devs.Application/. ./src/projects/kodlama.io/Core/Devs.Application/
COPY src/projects/kodlama.io/Core/Devs.Domain/. ./src/projects/kodlama.io/Core/Devs.Domain/
COPY src/projects/kodlama.io/Infrastructure/Devs.Infrastructure/. ./src/projects/kodlama.io/Infrastructure/Devs.Infrastructure/
COPY src/projects/kodlama.io/Infrastructure/Devs.Persistence/. ./src/projects/kodlama.io/Infrastructure/Devs.Persistence/
COPY src/projects/kodlama.io/Presentation/Devs.WebAPI/. ./src/projects/kodlama.io/Presentation/Devs.WebAPI/
WORKDIR /source/src/projects/kodlama.io/Presentation/Devs.WebAPI
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
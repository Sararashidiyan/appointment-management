
## Build stage
#FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
#WORKDIR /src
#
## Copy solution and restore dependencies
#COPY ../AppointmentManagement.sln ./
#COPY ../Domain/AppointmentManagement.Domain.csproj ./AppointmentManagement.Domain/
#COPY ../Infrastructure/AppointmentManagement.Infrastructure.csproj ./AppointmentManagement.Infrastructure/
#COPY ../Application/AppointmentManagement.Application.csproj ./AppointmentManagement.Application/
#COPY ./AppointmentManagement.Api.csproj ./AppointmentManagement.Api/
#RUN dotnet restore "./AppointmentManagement.Api/AppointmentManagement.Api.csproj"
#
## Copy everything else and build
#COPY ../AppointmentManagement.sln ./
#COPY ../Domain/AppointmentManagement.Domain ./AppointmentManagement.Domain/
#COPY ../Infrastructure/AppointmentManagement.Infrastructure ./AppointmentManagement.Infrastructure/
#COPY ../Application/AppointmentManagement.Application ./AppointmentManagement.Application/
#COPY . .
#WORKDIR /src/AppointmentManagement
#RUN dotnet publish -c Release -o /app/publish
#
## Runtime stage
#FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
#WORKDIR /app
#COPY --from=build /app/publish .
#ENTRYPOINT ["dotnet", "AppointmentManagement.Api.dll"]
#


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy solution and project files
COPY   . ./

# Restore dependencies
RUN dotnet restore AppointmentManagement.sln
#

RUN dotnet publish AppointmentManagement.Api.csproj -c Release -o /out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "AppointmentManagement.Api.dll"]

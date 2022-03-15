#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApps/MicroserviceWebBlazor/Microservices.WebAssemblyBlazor/Microservices.WebAssemblyBlazor.csproj", "WebApps/MicroserviceWebBlazor/Microservices.WebAssemblyBlazor/"]
RUN dotnet restore "WebApps/MicroserviceWebBlazor/Microservices.WebAssemblyBlazor/Microservices.WebAssemblyBlazor.csproj"

COPY /src .
RUN dotnet build "Microservices.WebAssemblyBlazor.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "Microservices.WebAssemblyBlazor.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

COPY --from=publish /publish/wwwroot /usr/local/webapp/nginz/html
COPY nginx.conf /etc/nginx/nginx.conf

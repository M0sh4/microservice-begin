#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Microservice.api.Seguridad.csproj", "Micrioservice.api.Seguridad/"]
RUN dotnet restore "Micrioservice.api.Seguridad/Microservice.api.Seguridad.csproj"
COPY . .
WORKDIR "/src/Micrioservice.api.Seguridad"
RUN dotnet build "Microservice.api.Seguridad.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.api.Seguridad.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet"]

CMD ["/bin/Debug/net5.0/Micrioservice.api.Seguridad.dll"]
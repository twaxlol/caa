#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductOrder.API/ProductOrder.API.csproj", "ProductOrder.API/"]
COPY ["ProductOrder.Application/ProductOrder.Application.csproj", "ProductOrder.Application/"]
COPY ["ProductOrder.Infrastructure/ProductOrder.Infrastructure.csproj", "ProductOrder.Infrastructure/"]
COPY ["ProductOrder.Core/ProductOrder.Core.csproj", "ProductOrder.Core/"]
RUN dotnet restore "ProductOrder.API/ProductOrder.API.csproj"
COPY . .
WORKDIR "/src/ProductOrder.API"
RUN dotnet build "ProductOrder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductOrder.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductOrder.API.dll"]
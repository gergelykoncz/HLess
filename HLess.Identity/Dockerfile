FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["HLess.Identity/HLess.Identity.csproj", "HLess.Identity/"]
RUN dotnet restore "HLess.Identity/HLess.Identity.csproj"
COPY . .
WORKDIR "/src/HLess.Identity"
RUN dotnet build "HLess.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HLess.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HLess.Identity.dll"]
# Use the official .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

# Use the official .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the project files to the container
COPY ["SeleniumCSharp/SeleniumCSharp.csproj", "SeleniumCSharp/"]

# Restore dependencies
RUN dotnet restore "SeleniumCSharp/SeleniumCSharp.csproj"
COPY . .
WORKDIR "/src/SeleniumCSharp"

# Build the project
RUN dotnet build "SeleniumCSharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeleniumCSharp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeleniumCSharp.dll"]

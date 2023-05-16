# Use the official .NET Core SDK as the base image
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base

# Install Chrome and ChromeDriver dependencies
RUN apt-get update && apt-get install -yq wget curl gnupg

# Install Chrome
RUN curl -sSL https://dl.google.com/linux/linux_signing_key.pub | apt-key add -
RUN echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google-chrome.list
RUN apt-get update && apt-get install -yq google-chrome-stable

# Install ChromeDriver
RUN wget -q -O /tmp/chromedriver.zip https://chromedriver.storage.googleapis.com/LATEST_RELEASE/chromedriver_linux64.zip
RUN unzip /tmp/chromedriver.zip -d /usr/local/bin/

# Set ChromeDriver path
ENV PATH "$PATH:/usr/local/bin"

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

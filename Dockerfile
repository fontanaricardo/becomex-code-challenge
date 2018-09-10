FROM microsoft/dotnet:2.1-sdk-alpine as build-env

# Set the Working Directory
WORKDIR /app

# Copy the app
COPY . /app

# Restore and publish the app
RUN dotnet publish -r alpine-x64 -c Release -o /app/out /app/src/RoboApi/RoboApi.csproj

FROM microsoft/dotnet:2.1-runtime-alpine

WORKDIR /app

# Copy the app from the build environment
COPY --from=build-env /app/out ./

# Configure the listening port to 80
ENV ASPNETCORE_URLS http://*:80

EXPOSE 80

# Fix the permission
RUN chmod +x /app/RoboApi

ENTRYPOINT ["./RoboApi"]
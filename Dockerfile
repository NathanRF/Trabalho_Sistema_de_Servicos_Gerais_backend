FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /app
EXPOSE 80

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
RUN dotnet ef database update -c ApplicationDbContext
CMD ASPNETCORE_URLS=http://*:$PORT dotnet out/SSG_API.dll

# ENTRYPOINT ["dotnet", "Colors.API.dll"]
# heroku uses the following
#CMD ASPNETCORE_URLS=https://*:$PORT dotnet SSG_API.dll
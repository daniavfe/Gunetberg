FROM mcr.microsoft.com/dotnet/aspnet:7.0
COPY publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Gunetberg.Host.dll"]
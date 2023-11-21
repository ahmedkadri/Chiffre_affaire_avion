#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copiez le fichier csproj et restaurez les dépendances
COPY . .
RUN dotnet restore

# Copiez le reste des fichiers et construisez l'application
COPY . .
RUN dotnet publish -c Release -o /app

# Utilisez une image plus légère pour exécuter l'application
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS runtime
WORKDIR /app
COPY --from=build /app ./

# Commande pour démarrer l'application au lancement du conteneur
ENTRYPOINT ["dotnet", "Chiffre_affaire_avion_Console.dll"]  # Remplacez "NomDeVotreFichier.dll" par le fichier de sortie réel de votre projet
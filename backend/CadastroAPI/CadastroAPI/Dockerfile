# Estágio 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copie o arquivo do projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copie o código do aplicativo
COPY . ./

# Execute o build da aplicação
RUN dotnet publish -c Release -o out

# Estágio 2: Publicação
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copie os arquivos construídos do estágio anterior
COPY --from=build /app/out ./

# Exponha a porta utilizada pela aplicação
EXPOSE 80

# Comando padrão para iniciar a aplicação
CMD ["dotnet", "CadastroAPI.dll"]

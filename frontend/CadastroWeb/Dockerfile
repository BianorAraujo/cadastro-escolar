# Use a imagem oficial do Node.js LTS como base
FROM node:lts-alpine AS builder

# Defina o diretório de trabalho
WORKDIR /app

# Copie os arquivos de configuração
COPY package.json .
COPY package-lock.json .

# Instale as dependências
RUN npm install

# Copie o código da aplicação
COPY . .

# Execute o build da aplicação
RUN npm run build

# Imagem final para servir a aplicação Angular
FROM nginx:alpine

# Remova a configuração padrão do Nginx
RUN rm -rf /usr/share/nginx/html/*

# Copie os arquivos construídos do estágio anterior para o diretório padrão do Nginx
COPY --from=builder /app/dist/cadastro-web /usr/share/nginx/html

# Exponha a porta 80 para acessar a aplicação
EXPOSE 80

# Comando padrão para iniciar o servidor Nginx
CMD ["nginx", "-g", "daemon off;"]

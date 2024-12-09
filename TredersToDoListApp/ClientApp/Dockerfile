# Etap 1: Budowanie aplikacji Angular
FROM node:18 AS build
WORKDIR /app

# Kopiowanie plików package.json i package-lock.json
COPY package*.json ./

# Instalowanie zależności
RUN npm install

# Kopiowanie reszty plików projektu
COPY . .

# Budowanie aplikacji Angular
RUN npm run build --prod

# Etap 2: Serwowanie aplikacji Angular za pomocą Nginx
FROM nginx:1.25

# Kopiowanie zbudowanej aplikacji do domyślnej lokalizacji Nginx
COPY --from=build /app/dist/treders-to-do-list-app-fe /usr/share/nginx/html

# Eksponowanie portu 4200
EXPOSE 80

# Start serwera Nginx
CMD ["nginx", "-g", "daemon off;"]

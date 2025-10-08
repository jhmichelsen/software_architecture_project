# Build stage
FROM node:20 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .

ARG REACT_APP_FACTORY_API
ARG REACT_APP_WATER_API
ENV REACT_APP_FACTORY_API=$REACT_APP_FACTORY_API
ENV REACT_APP_WATER_API=$REACT_APP_WATER_API

RUN npm run build

# Serve stage
FROM nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

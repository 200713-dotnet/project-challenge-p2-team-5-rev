FROM node:current as build
WORKDIR /workspace
COPY . .
RUN npm ci
RUN npm run build
CMD [ "npm", "start" ]
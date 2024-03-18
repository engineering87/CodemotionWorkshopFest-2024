/** @format */
import swaggerAutogen from 'swagger-autogen';

const outputFile = './swagger.json';
const endpointsFiles = ['../../server.mjs', '../routes/API.api.routes.mjs'];

export const generateSwagger = (app) => {
  swaggerAutogen(outputFile, endpointsFiles);
};

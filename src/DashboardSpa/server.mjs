/** @format */

import dotenv from 'dotenv';

/* MAIN Express */
import express from 'express';
import open from 'open';
import path, { dirname } from 'path';
import { fileURLToPath } from 'url';
/* loggers and extras */
import logger from 'morgan';
import { VerbalHelper } from './server/lib/extras.mjs';
/* SWAGGER */
import swaggerUi from 'swagger-ui-express';
import swaggerDocument from './server/swagger/swagger.json' assert { type: 'json' };
/* ROUTERS */
import API from './server/routes/API.api.routes.mjs';

dotenv.config({ path: path.resolve('./dev.env.server') });

export const __filename = fileURLToPath(import.meta.url);
export const __dirname = dirname(__filename);

const app = express();
var router = express.Router();

app.use(logger(process.env.MORGANLEVEL));
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

/* Routes */
app.use(router);

// Serve static files from the build folder
app.use(express.static(path.join(__dirname, 'build')));

// Route for serving the React app
app.get(/^\/(?!api|api-docs).*/, (req, res) => {
  res.sendFile(path.join(__dirname, 'build', 'index.html'));
});

app.use('/api/*', API);
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerDocument));

process.env.PORT = process.env.PORT || 5000;
app.listen(process.env.PORT);
VerbalHelper();

if (process.env.enviroment === 'DEV') {
  // opens the url in the default browser
  open(`http://localhost:${process.env.PORT}/`, { app: { name: 'chrome' } });
}

/** @format */

import axios from 'axios';
import express from 'express';
import https from 'https';
/* modules */
var router = express.Router();

router.all('/*', function (req, res, next) {
  let { baseUrl, method, body } = req;

  let config = {
    url: `${process.env.API_HOSTNAME}${baseUrl}`,
    method,
    httpsAgent: new https.Agent({
      rejectUnauthorized: false,
    }),
  };
  if (body) config.data = body;
  axios(config)
    .then((response) => {
      res.status(200).send(response.data);
    })
    .catch((err) => {
      res.status(500).send(err);
    });
});

export default router;

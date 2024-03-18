'use strict';
import exphbs from 'express-handlebars';

var hbs = exphbs.create({defaultLayout: 'layout', extname: '.handlebars'});
module.exports = hbs;
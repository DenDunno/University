'use strict';
var app = require('angular').module('parcs');

app.factory('chartService', require('./chart.service'));
app.factory('dataService', require('./data.service'));
app.factory('constants', require('./constants'));
app.factory('authService', require('./auth.service'));
app.factory('authInterceptorService', require('./authInterceptor.service'));

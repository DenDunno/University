'use strict';

var angular = require('angular');

require('angular-ui-bootstrap');
require('angular-local-storage');
require('angular-ui-router');

var app = angular.module('parcs', ['LocalStorageModule', 'ui.router', 'ui.bootstrap']);

// one require statement per sub directory instead of one per file

require('./js/controllers');
require('./js/services');
require('./js/directives');


app.config(require('./js/authConfig'));
app.config(require('./js/routeConfig'));
app.run(require('./js/appRun'));

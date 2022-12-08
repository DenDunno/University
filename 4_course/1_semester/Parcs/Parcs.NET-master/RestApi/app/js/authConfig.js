authConfig.$inject = ['$httpProvider'];

function authConfig ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
}

module.exports = authConfig;
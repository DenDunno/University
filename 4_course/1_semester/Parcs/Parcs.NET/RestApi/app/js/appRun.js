appRun.$inject = ['$rootScope', 'authService'];

function appRun($rootScope, authService) {
    //log all $stateChangeError events since ui-router silently swallows such errors
    $rootScope.$on("$stateChangeError", console.log.bind(console));
    authService.fillAuthData();
}
    
module.exports = appRun;   
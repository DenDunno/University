var navbarComponent = {
    templateUrl: 'app/views/navbar.html',
    controller: navbarController
};

navbarController.$inject = ['authService', '$location'];
function navbarController(authService, $location) {
    var vm = this;
    vm.logOut = function() {
        authService.logOut();
        $location.path('/');
    };

    vm.authentication = authService.authentication;
}

module.exports = navbarComponent;
module.exports = configRoutes;

configRoutes.$inject = ["$stateProvider", "$urlRouterProvider"];

function configRoutes($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise(function($injector) {
        var $state = $injector.get("$state");
        $state.go("main");
    });

    $stateProvider.state('login', {
        url: "/login",
        controller: "loginController",
        templateUrl: "/app/views/login.html"   
    });

    $stateProvider.state("main", {
        url: "/",
        controller: "MainController",
        controllerAs: "main",
        templateUrl: "/app/views/main.html"
    });

    $stateProvider.state("signup", {
        url: "/signup",
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $stateProvider.state("about", {
        url: "/about",
        templateUrl: "/app/views/about.html",
        controller: "aboutController"
    });
}
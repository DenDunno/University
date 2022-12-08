'use strict';
loginController.$inject = ['$scope', '$location', 'authService']; 

function loginController ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

            $location.path('');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };
}

module.exports = loginController;

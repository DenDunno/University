'use strict';
aboutController.$inject = ['$scope', '$timeout'];

function aboutController ($scope, $timeout) {

    $scope.surprise = "";

    var promise;

    $scope.onSurpriseMouseOver = function() {
        promise = $timeout(function() {
            $scope.surprise = "app/resources/surprise.png"
        }, 1000);
    };

    $scope.onSurpriseMouseLeave = function() {
        $timeout.cancel(promise);
        $scope.surprise = "";
    };
}

module.exports = aboutController;

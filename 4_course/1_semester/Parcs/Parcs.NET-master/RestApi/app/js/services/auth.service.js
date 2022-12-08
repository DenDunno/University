AuthService.$inject = ['$http', '$q', '$rootScope', 'localStorageService'];

function AuthService($http, $q, $rootScope, localStorageService) {

    var authServiceFactory = {};

    var authentication = {
        isAuth: false,
        userName : ""
    };

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post('api/account/register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post('token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

            authentication.isAuth = true;
            authentication.userName = loginData.userName;

            deferred.resolve(response);

        }).error(function (err, status) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');
        authentication.isAuth = false;
        authentication.userName = "";

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData)
        {
            authentication.isAuth = true;
            authentication.userName = authData.userName;
        }

    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = authentication;

    return authServiceFactory;
};

module.exports = AuthService;
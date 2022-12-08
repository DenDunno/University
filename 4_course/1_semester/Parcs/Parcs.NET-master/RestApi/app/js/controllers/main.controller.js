function MainController($scope, $timeout, constants, dataService, authService, $uibModal) {

    $scope.charts = [constants.charts.processors, constants.charts.benchmark];
    $scope.data = {
        hosts: [],
        jobs: [],
        logs: [],
        chartsData: []
    };

    $scope.jobStatuses = constants.jobStatuses;

    (function getHostsFromServer() {
        dataService.getHosts().then(function(response) {
            angular.merge($scope.data.hosts, response.data);
            $scope.data.chartsData = angular.copy($scope.data.hosts);
            $timeout(getHostsFromServer, constants.serverQueryTimeout);
        });
    })();

    (function getJobsFromServer() {
        dataService.getJobs().then(function(response) {
            angular.merge($scope.data.jobs, response.data);
            $timeout(getJobsFromServer, constants.serverQueryTimeout);
        });
    })();

    (function getLogsFromServer() {
        dataService.getLogs().then(function(response) {
            $scope.data.logs = response.data;
            $timeout(getLogsFromServer, constants.serverQueryTimeout);
        });
    })();

    $scope.cancelJob = function(job, $event) {
        $event.preventDefault();
        $event.stopPropagation();
        dataService.cancelJob(job).then(function() {

        });
    };

    $scope.addJob = function() {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'app/views/addJobModal.html',
            controller: 'addJobModalController',
            controllerAs: 'modal',
            size: 'sm',
            backdrop: 'static'
        });
    };
    
    $scope.isAuthenticated = function() { return authService.authentication.isAuth; }
    
    dataService.saveAvailableModules();
}

module.exports = MainController;
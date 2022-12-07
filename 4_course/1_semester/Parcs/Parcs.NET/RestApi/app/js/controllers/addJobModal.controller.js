'use strict';
AddJobModalController.$inject = ['$scope', 'constants', '$uibModalInstance', 'dataService'];

function AddJobModalController ($scope, constants, $uibModalInstance, dataService) {
    var modules = dataService.getAvailableModules();
    
    $scope.jobs = modules || [];
    
    if (modules) {
        $scope.selectedJob = $scope.jobs[0];
    } else {
        dataService.saveAvailableModules().then(function(response) {
            $scope.jobs = response.data;
            $scope.selectedJob = $scope.jobs[0]; 
        });    
    }
    
    $scope.setJob = function(job) {
        $scope.selectedJob = job;  
    };
    
    $scope.jobOptions = {
        priority: 0,
        commandLineParameters: ''
    };

    $scope.startJob = function() {
        dataService.startJob(angular.extend($scope.jobOptions, {name: $scope.selectedJob.name})).then(function() {
            $uibModalInstance.close('ok');
        });
    };

    $scope.cancel = function() {
        $uibModalInstance.dismiss('cancel');
    };
}

module.exports = AddJobModalController;

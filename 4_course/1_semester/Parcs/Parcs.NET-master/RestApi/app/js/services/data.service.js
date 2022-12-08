module.exports = function($http, constants) {

    return {
        getHosts: getHosts,
        getJobs: getJobs,
        getLogs: getLogs,
		cancelJob: cancelJob,
		startJob: startJob,
        getAvailableModules: getAvailableModules,
        saveAvailableModules: saveAvailableModules
    };

    function getHosts() {
        return $http.get(constants.urls.hosts);
    }

    function getJobs() {
        return $http.get(constants.urls.jobs);
    }

    function getLogs() {
        return $http.get(constants.urls.logs);
    }

    function getPreparedJobs(jobs) {
        return jobs.map(function(job) {
            return {
                number: job.number,
                priority: job.priority,
                status: job.jobStatus,
                points: job.points
            }
        })
    }

    function cancelJob(job) {
        return $http.post(constants.urls.cancelJob, {number: job.number});
    }

    function startJob(options) {
        return $http.post(constants.urls.startJob, options);
    }
    
    
    var availableModules;
    
    function getAvailableModules() {
        return availableModules;
    }
    
    function saveAvailableModules() {
        return $http.get(constants.urls.modules).then(function(response){
           availableModules = response.data;
           return availableModules; 
        });
    }
};




module.exports = function() {
    return {
        charts: {
            processors: {
                title: 'Performance by Processors',
                color: '#28ABE3',
                yAxis: {
                    min: 0,
                    max: 1,
                    labels: {
                        formatter: function() {
                            return (this.value * 100).toFixed() + '%';
                        }
                    }
                }
            },
            benchmark: {
                title: 'Performance by Benchmark',
                color: '#1FDA9A',
                yAxis: {
                    min: 0,
                    max: 1,
                    labels: {
                        formatter: function() {
                            return (this.value * 100).toFixed() + '%';
                        }
                    }
                }
            }
        },

        urls: {
            jobs: '/api/parcs/job',
            hosts: '/api/parcs/host/list',
            logs: '/api/log',
            cancelJob: '/api/parcs/cancelJob',
            startJob: 'api/module/run',
            modules: 'api/module'
        },

        jobStatuses: {
            running: 'Running',
            partlyRunning: 'Partly',
            pending: 'Pending',
            finished: 'Finished',
            cancelled: 'Cancelled'
        },
        
        serverQueryTimeout: 3000
    }
};
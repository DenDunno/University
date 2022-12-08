module.exports = function(constants) {

    var chartDataMap = {};
    chartDataMap[constants.charts.processors.title] = getProcessorsPerformanceChartValue;
    chartDataMap[constants.charts.benchmark.title] = getBenchmarkPerformanceChartValue;

    return {
        getChartData: getChartData
    };

    function getChartData(chartTitle, response) {
        return chartDataMap[chartTitle](response);
    }

    function getProcessorsPerformanceChartValue(response) {
        var pointCountSum = 0, processorCountSum = 0;
        response.forEach(function(host) {
            pointCountSum += host.pointCount;
            processorCountSum += host.processorCount;
        });

        if (!processorCountSum) {
            return 0;
        }

        return parseFloat((pointCountSum / processorCountSum).toFixed(2));
    }

    function getBenchmarkPerformanceChartValue(response) {
        var pointCountSum = 0, processorCountSum = 0;
        response.forEach(function(host) {
            pointCountSum += host.pointCount * host.linpackResult;
            processorCountSum += host.processorCount * host.linpackResult;
        });

        if (!processorCountSum) {
            return 0;
        }

        return parseFloat((pointCountSum / processorCountSum).toFixed(2));
    }
};




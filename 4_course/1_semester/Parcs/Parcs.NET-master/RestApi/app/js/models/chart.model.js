var Highcharts = require('highcharts');
var noData = require('highcharts/modules/no-data-to-display');
noData(Highcharts);

Highcharts.setOptions({
    global: {
        useUTC: false
    },
    lang: {
        noData: 'Waiting for data'
    }
});

var chartOptions = {
    chart: {
        type: 'spline',
        animation: Highcharts.svg,
        marginRight: 10,
        zoomType: 'x'
    },
    title: {
        text: null
    },
    xAxis: {
        type: 'datetime',
        tickPixelInterval: 150
    },
    yAxis: {
        title: {
            text: null
        }
    },
    tooltip: {
        useHtml: true,
        xDateFormat: '%H:%M:%S',
        pointFormat: '<span style="color:{point.color}">\u25CF</span><b>{point.y}</b><br/>'
    },
    legend: {
        enabled: false
    },
    exporting: {
        enabled: false
    },
    credits: {
        enabled: false
    },
    series: [{
        data: []
    }]
};

function Chart(options) {
    this.setOptions(options);
}

Chart.prototype.draw = function(element) {
    this.chart = Highcharts.chart(element, this.options);
};

Chart.prototype.setOptions = function(options) {
    chartOptions.title.text = options.title;
    chartOptions.series[0].name = options.title;
    chartOptions.series[0].color = options.color;
    
    angular.merge(chartOptions.yAxis, options.yAxis);
    
    this.options = chartOptions;
};

Chart.prototype.addPoint = function(value) {
    var series = this.chart.series[0];
    series.addPoint([new Date().getTime(), value], true, series.points.length > 30); //move to constants

};

module.exports = Chart;
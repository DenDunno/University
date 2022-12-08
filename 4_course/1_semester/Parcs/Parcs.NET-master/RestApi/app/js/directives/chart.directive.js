var Chart = require('./../models/chart.model');
function ChartDirective (chartService) {
    return {
        restrict: 'E',
        template: '<div class="analytics-chart"></div>',
        replace: true,
        scope: {
            options: '=',
            data: '='
        },
        link: function($scope) {
            console.log($scope);
        },
        controller: function($scope, $element) {
            var vm = this;

            $scope.$watch('vm.data.chartsData', function() {
               if (!vm.data.chartsData.length) {
                   return;
               }
               var pointValue = chartService.getChartData(vm.options.title, vm.data.chartsData);
               vm.chart.addPoint(pointValue);
            });

            vm.chart = new Chart(vm.options);
            vm.chart.draw($element[0]);

        },
        bindToController: true,
        controllerAs: 'vm'
    };
}

 module.exports = ChartDirective;
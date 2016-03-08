(function() {
    'use strict';

    angular
        .module('mainApp')
        .controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = ['userDataSvc', '$log', 'NgTableParams', 'customeOrderbyFilterSvc'];

    function homeCtrl(userDataSvc, $log, NgTableParams, customeOrderbyFilterSvc) {
        /* jshint validthis:true */
        var vm = this;
        vm.data = [];

        // Disable weekend selection
        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }

        vm.dateOptions = {
            dateDisabled: disabled,
            formatYear: 'yy',
            maxDate: new Date(2020, 5, 22),
            minDate: new Date(),
            startingDay: 1
        };

        vm.openDatePopup = function (row) {
            row.opened = true;
        };

        vm.tableSettings = {
            pagingVisible: false,
            curNgSortOrder: null
        };
        
        vm.tableParams = new NgTableParams(
            { page: 1, count: 8 },
            {
                total: 100,
                counts: [],
                getData: function($defer, params) {
                    var count = params.count();
                    var page = params.page() - 1;
                    var currentPageData = [];

                    if (vm.data && vm.data.length > 0) {
                        vm.tableParams.total(vm.data.length);

                        if (params.sorting() != vm.tableSettings.curNgSortOrder) {
                            //If the sorting is changed resort the data
                            vm.tableSettings.curNgSortOrder = params.sorting();

                            if (params.sorting()) {
                                var sortCol = params.orderBy()[0] ? params.orderBy()[0] : null; //only support single col sorting at the moment
                                if (sortCol) {
                                    vm.data = customeOrderbyFilterSvc.orderbyFilterEmptyFirst(sortCol, vm.data);
                                }
                            }
                        }

                        if (vm.data.length > count) {
                            var startIndex = page * count;
                            var endIndex = startIndex + count;
                            currentPageData = vm.data.slice(startIndex, endIndex);
                            vm.tableSettings.pagingVisible = true;
                        } else {
                            currentPageData = vm.data;
                            vm.tableSettings.pagingVisible = false;
                        }
                    } else {
                        vm.tableParams.total(0);
                    }

                    $defer.resolve(currentPageData);
                }
            }
        );

        (function () {
            userDataSvc.getUsers().then(
                function (data) {
                    vm.data = data;
                    $log.log(JSON.stringify(data));
                    vm.tableParams.reload();
                }, function rejected(reason) {
                    $log.error(reason);
                }, function notify(update) {
                    $log.info(update);
                });
        })();
    }
})();

(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = ['userDataSvc', '$log', '$injector'];

    function homeCtrl(userDataSvc, $log, $injector) {
        /* jshint validthis:true */
        var vm = this;

        vm.tableSettings = {
            pagingVisible: false
        };

        var NgTableParams = $injector.get('NgTableParams');

        vm.tableParams = new NgTableParams(
           { page: 1, count: 8 },
           {
               total: 100,
               counts: [],
               getData: function ($defer, params) {
                   var count = params.count();
                   var page = params.page() - 1;
                   var currentPageData = [];

                   if (vm.data && vm.data.length > 0) {
                       vm.tableParams.total(vm.data.length);

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

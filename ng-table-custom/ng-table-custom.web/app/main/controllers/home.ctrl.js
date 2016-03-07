(function () {
    'use strict';

    angular
        .module('mainApp')
        .controller('homeCtrl', homeCtrl);

    homeCtrl.$inject = ['userDataSvc', '$log']; 

    function homeCtrl(userDataSvc, $log) {
        /* jshint validthis:true */
        var vm = this;
        
        (function () {
            userDataSvc.getUsers().then(
                function (data) {
                    $log.log(JSON.stringify(data));
                }, function rejected(reason) {
                    $log.error(reason);
                }, function notify(update) {
                    $log.info(update);
                });
        })();
    }
})();

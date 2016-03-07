(function () {
    'use strict';

    angular
        .module('dataApp')
        .factory('userDataSvc', userDataSvc);

    userDataSvc.$inject = ['$resource', '$q'];

    function userDataSvc($resource, $q) {
        var service = {
            getUsers: _getUsers,
            getUser: _getUser
        };

        var resource = $resource('/api/users/:userId', { userId: '@userId'});

        return service;

        function _getUsers() {
            var deferred = $q.defer();
            resource.query({},
				function (data) {
				    deferred.resolve(data);
				},
				function (error) {
				    deferred.reject(error);
				});
            return deferred.promise;
        }

        function _getUser(userId) {
            var deferred = $q.defer();
            resource.get({ userId: userId },
				function (data) {
				    deferred.resolve(data);
				},
				function (error) {
				    deferred.reject(error);
				});
            return deferred.promise;
        }
    }
})();
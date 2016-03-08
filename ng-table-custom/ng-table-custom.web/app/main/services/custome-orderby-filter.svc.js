(function () {
    'use strict';

    angular
        .module('mainApp')
        .factory('customeOrderbyFilterSvc', customeOrderbyFilterSvc);

    customeOrderbyFilterSvc.$inject = ['$filter'];

    function customeOrderbyFilterSvc($filter) {
        var tableSettingsSortColumn = '';

        var service = {
            orderbyFilterEmptyFirst: _orderbyFilterEmptyFirst
        };

        return service;

        function _orderbyFilterEmptyFirst(col, itemArr) {
            tableSettingsSortColumn = col;
            var sorted = $filter('orderBy')(itemArr, comparatorFunc, (col.indexOf('-') > -1));
            return sorted;
        }

        //Custom filter comparator that will sort the empty values in the top. 
        function comparatorFunc(actual) {
            var val = null;
            var colName = null;

            if (tableSettingsSortColumn.indexOf('.') > -1) {//if the value is inside an object
                colName = tableSettingsSortColumn.substring(1, tableSettingsSortColumn.length);
                var colName0 = colName.substring(0, colName.indexOf('.'));
                var colName1 = colName.substring(colName.indexOf('.') + 1, colName.length);
                val = actual[colName0][colName1];
            } else {
                colName = tableSettingsSortColumn.substring(1, tableSettingsSortColumn.length);
                val = actual[colName];
            }

            if (val !== null) {
                return val;
            } else {
                return 0;
            }
        }
    }
})();
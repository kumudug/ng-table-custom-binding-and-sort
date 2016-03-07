describe('homeCtrl unit tests', function () { 

    var $controllerConstructor, userDataSvc, $log;
    var users = [];

    //Setup

    beforeEach(module('dataMockApp'));
    beforeEach(module('dataApp'));
    beforeEach(module('mainApp'));

    beforeEach(inject(function ($controller, $log, $injector) {
        $controllerConstructor = $controller;
        userDataSvc = $injector.get('userDataSvc'); //make sure dataMockApp module is used
        NgTableParams = $injector.get('NgTableParams');
        $log = $log;
    }));

    it('Check whether vm.data is correct', function () {
        var ctrl = $controllerConstructor('homeCtrl', { 'userDataSvc': userDataSvc, '$log': $log, 'NgTableParams': NgTableParams });
        expect(ctrl).toBeDefined();
    });
});

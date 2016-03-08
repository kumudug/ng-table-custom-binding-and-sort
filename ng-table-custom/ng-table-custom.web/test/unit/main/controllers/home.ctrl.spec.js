describe('homeCtrl unit tests', function () { 

    var $controllerConstructor, userDataSvc, log, ngTableParams, timeout, customeOrderbyFilterSvc;
    var homeCtrl;
    
    beforeEach(module('dataMockApp'));
    beforeEach(module('dataApp'));
    beforeEach(module('mainApp'));

    beforeEach(inject(function ($controller, $injector) {
        $controllerConstructor = $controller;
        userDataSvc = $injector.get('userDataSvc'); //make sure dataMockApp module is used
        ngTableParams = $injector.get('NgTableParams');
        customeOrderbyFilterSvc = $injector.get('customeOrderbyFilterSvc');
        log = $injector.get('$log');
        timeout = $injector.get('$timeout');
        homeCtrl = $controllerConstructor('homeCtrl', { 'userDataSvc': userDataSvc, '$log': log, 'NgTableParams': ngTableParams, 'customeOrderbyFilterSvc': customeOrderbyFilterSvc });
    }));

    it('Check whether vm is correctly defined', function () {
        expect(homeCtrl).toBeDefined();
        expect(homeCtrl.data).toBeDefined();
        expect(homeCtrl.tableParams).toBeDefined();
    });

    it('Check whether data is retrieved', function () {
        timeout.flush(); //force digest cycle
        expect(homeCtrl.data.length).toBeGreaterThan(1);
        expect(homeCtrl.data.length).toBe(10);
    });

    //Teardown
    afterEach(function () {
        
    });
});

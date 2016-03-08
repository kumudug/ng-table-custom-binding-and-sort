
//Test suite
describe('customeOrderbyFilterSvc unit tests', function () {

    var customeOrderbyFilterSvc;

    beforeEach(module('dataMockApp'));
    beforeEach(module('dataApp'));
    beforeEach(module('mainApp'));
    
    beforeEach(inject(function ($injector) {
        customeOrderbyFilterSvc = $injector.get('customeOrderbyFilterSvc'); 
    }));

    //Spec - 1
    it('Checks if the empty values are put to the top', function () {
        var users = [
            {
                userId: 1,
                firstName: 'Manuel',
                lastName: 'French',
                dob: new Date('8/24/1980')
            },
            {
                userId: 2,
                firstName: null,
                lastName: 'Palmer',
                dob: new Date('2/24/1990')
            },
            {
                userId: 3,
                firstName: 'Sheldon',
                lastName: 'Holmes',
                dob: new Date('5/24/1987')
            }
        ];

        var sortedUsers = customeOrderbyFilterSvc.orderbyFilterEmptyFirst('+firstName', users);
        expect(sortedUsers.length).toBe(users.length);
        expect(sortedUsers[0].userId).toBe(2);
    });
    
    //Teardown
    afterEach(function () {
    });
});

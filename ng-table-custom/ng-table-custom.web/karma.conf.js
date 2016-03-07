/// <reference path="Lib/ng-table/dist/ng-table.js" />
// Karma configuration file

module.exports = function (config) {
    config.set({

        // base path, that will be used to resolve files and exclude
        basePath: '',

        // frameworks to use
        // possible values: 'jasmine', 'mocha'
        frameworks: ['bower', 'jasmine', 'sinon'],

        //then you can load any package from bower into your tests using karma-bower
        bowerPackages: [
            'jquery',
            'angular',
            'angular-mocks',
            'angular-ui-router',
            'angular-bootstrap',
            'angular-resource',
            'sweetalert',
            'ng-table'
        ],

        // list of files / patterns to load in the browser
        files: [
            //'Lib/ng-table/dist/ng-table.min.js',
            'app/data-mock/*.js',
            //'app/data/data-app.mdl.js',
            //'app/data/**/*.js',
            //'app/main/*.js',
            //'app/main/**/*.js',
            'app/ng-table-custom.web.data.js',
            'app/ng-table-custom.web.main.js',
            'test/unit/**/*.js'
        ],

        // list of files to exclude
        exclude: [

        ],

        // test results reporter to use
        // possible values: 'dots', 'progress', 'junit', 'growl', 'coverage'
        reporters: ['progress'],

        // web server port
        port: 9876,

        // enable / disable colors in the output (reporters and logs)
        colors: true,

        // level of logging
        // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
        logLevel: config.LOG_INFO,

        // enable / disable watching file and executing tests whenever any file changes
        autoWatch: true,

        // Start these browsers, currently available:
        // - Chrome
        // - ChromeCanary
        // - Firefox
        // - Opera (has to be installed with `npm install karma-opera-launcher`)
        // - Safari (only Mac; has to be installed with `npm install karma-safari-launcher`)
        // - PhantomJS
        // - IE (only Windows; has to be installed with `npm install karma-ie-launcher`)
        //browsers: ['Chrome', 'Firefox', 'IE'],
        browsers: ['Chrome'],

        // If browser does not capture in given timeout [ms], kill it
        captureTimeout: 60000,

        // Continuous Integration mode
        // if true, it capture browsers, run tests and exit
        singleRun: false
    });
};
module.exports = function (grunt) {

    // Configurable paths for the application
    var appConfig = {
        mainLoc: 'app/main',
        mainConcatFile: 'main'
    };

    grunt.initConfig({
        //imports the JSON metadata stored in package.json into the grunt config
        pkg: grunt.file.readJSON('package.json'),
        appSettings: appConfig,
        processhtml: {
            debug: {
                options: {
                    process: false,
                    data: {
                        message: 'This is development build'
                    }
                },
                files: {
                    'index.html': ['index.tpl.html']
                }
            },
            release: {
                options: {
                    process: false,
                    data: {
                        message: 'This is a release build'
                    }
                },
                files: {
                    'index.html': ['index.tpl.html']
                }
            }
        },
        bowerInstall: {
            debug: {
                // Point to the files that should be updated when 
                // you run `grunt bower-install` 
                src: [
                  'index.html'
                ],

                // Optional: 
                // --------- 
                cwd: '',
                dependencies: true,
                devDependencies: true,
                exclude: [],
                fileTypes: {},
                ignorePath: '',
                overrides: {
                    angular: {
                        main: "./angular.min.js"
                    },
                    bootstrap: {
                        main: ['dist/css/bootstrap.min.css',
                            'dist/css/bootstrap-theme.min.css',
                            'dist/js/bootstrap.min.js']
                    },
                    jquery: {
                        main: 'dist/jquery.min.js'
                    },
                    'angular-mocks': {
                        main: './angular-mocks.js'
                    }
                }
            },
            release: {
                // Point to the files that should be updated when 
                // you run `grunt bower-install` 
                src: [
                  'index.html'
                ],

                // Optional: 
                // --------- 
                cwd: '',
                dependencies: true,
                devDependencies: false,
                exclude: [],
                fileTypes: {},
                ignorePath: '',
                overrides: {
                    angular: {
                        main: "./angular.min.js"
                    },
                    bootstrap: {
                        main: ['dist/css/bootstrap.min.css',
                            'dist/css/bootstrap-theme.min.css',
                            'dist/js/bootstrap.min.js']
                    },
                    jquery: {
                        main: 'dist/jquery.min.js'
                    },
                    'angular-mocks': {
                        main: './angular-mocks.js'
                    }
                }
            }
        },
        jshint: {
            options: {
                reporter: 'checkstyle',
                reporterOutput: 'app/<%= pkg.name %>.<%= appSettings.mainConcatFile %>.jshint.output.xml'
            },
            // define the files to lint
            beforeconcat: ['gruntfile.js', 'bower.json', 'package.json', '<%= appSettings.mainLoc %>/**/*.js'],
            afterconcat: ['app/<%= pkg.name %>.<%= appSettings.mainConcatFile %>.js']
        },
        concat: {
            options: {
                // define a string to put between each file in the concatenated output
                separator: ' ',
                sourceMap: false
            },
            main: {
                // the files to concatenate
                src: [
                    '<%= appSettings.mainLoc %>/main-app.mdl.js',
                    '<%= appSettings.mainLoc %>/**/*.js'                ],
                // the location of the resulting JS file
                dest: 'app/<%= pkg.name %>.<%= appSettings.mainConcatFile %>.js'
            }
        }
    });

    grunt.loadNpmTasks('grunt-processhtml');
    grunt.loadNpmTasks('grunt-bower-install');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-concat');

    grunt.registerTask('default', ['processhtml:debug', 'bowerInstall:debug', 'jshint:beforeconcat', 'concat', 'jshint:afterconcat']);
    grunt.registerTask('release', ['processhtml:release', 'bowerInstall:release']);
};
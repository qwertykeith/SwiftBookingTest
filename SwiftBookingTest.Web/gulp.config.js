module.exports = function () {
    var client = './scripts/';
    var clientApp = client + 'app/';
    var config = {
        temp: './.tmp',
        alljs: [
            './scripts/app/**/*.js',
            './*.js'
        ],
        js: [
           clientApp + '**/*.module.js',
           clientApp + '**/*.js',
           '!' + clientApp + '**/*.spec.js'
        ],
        less: './Content/global.less',
        index: './Views/Shared/_Layout.cshtml',
        bower: {
            directory: ''
        }
    };

    /**
     * wiredep and bower settings
     */
    config.getWiredepDefaultOptions = function () {
        var options = {
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath
        };
        return options;
    };

    return config;
};
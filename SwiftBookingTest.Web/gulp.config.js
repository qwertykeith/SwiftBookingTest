module.exports = function () {
    var client = '';

    var config = {
        temp: './.tmp',
        alljs: [
            './scripts/app/**/*.js',
            './*.js'
        ],
        less: './Content/global.less'
    };
    return config;
};
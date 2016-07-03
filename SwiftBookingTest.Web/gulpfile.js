var gulp = require('gulp');
var args = require('yargs').argv;
var config = require('./gulp.config')();
var $ = require('gulp-load-plugins')({ lazy: true });


gulp.task('vet', function () {
    log('Vet task');
    return gulp
    .src(config.alljs)
    .pipe($.if(args.verbose, $.print()))
    .pipe($.jscs())
    .pipe($.jshint())
    .pipe($.jshint.reporter('jshint-stylish', { verbose: true }))
    .pipe($.jshint.reporter('fail'));
});

/**
 * Compile less to css
 * @return {Stream}
 */
gulp.task('styles', function () {
    log('Compiling Less --> CSS');

    return gulp
        .src(config.less)
        .pipe($.less())
        .pipe($.autoprefixer({ browsers: ['last 2 version', '> 5%'] }))
        .pipe(gulp.dest(config.temp));
});

/**
 * Log a message or series of messages using chalk's blue color.
 * Can pass in a string, object or array.
 */
function log(msg) {
    if (typeof (msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.blue(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.blue(msg));
    }
}
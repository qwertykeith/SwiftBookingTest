var gulp = require('gulp');
var args = require('yargs').argv;
var config = require('./gulp.config')();
var del = require('del');
var browserSync = require('browser-sync');

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
gulp.task('styles', ['clean-styles'], function () {
    log('Compiling Less --> CSS');

    return gulp
        .src(config.less)
        //.on($.plumber())
        .pipe($.less())
        .pipe($.autoprefixer({ browsers: ['last 2 version', '> 5%'] }))
        .pipe(gulp.dest(config.temp));
});

gulp.task('clean-styles', function () {
    var files = config.temp + '**/*.css';
    clean(files);
});

gulp.task('less-watcher', function () {
    gulp.watch(config.less, ['clean-styles']);
});

gulp.task('wiredep', function () {
    var options = config.getWiredepDefaultOptions();
    var wiredep = require('wiredep');
    return gulp
            .src(config.index)
            .pipe(wiredep(options))
            .pipe($.inject(gulp.src(config.js)))//todo config
            .pipe(gulp.dest(config.client));//TODO - config


});

gulp.task("start", function () {
    startBrowserSync();
});

/**
 * Start BrowserSync
 * --nosync will avoid browserSync
 */
function startBrowserSync() {
    if (browserSync.active) {
        return;
    }
    var port = 80;
    log('Starting BrowserSync on port ' + port);

    var options = {
        proxy: 'http://localhost/SwiftBookingTest.Web/#/',
        port: 80,
        files: [
            './scripts/**/*.*',
            './scripts/**/**/*.*',
            './scripts/**/**/**/*.*',
            './Controllers/*.*'
        ],
        ghostMode: { // these are the defaults t,f,t,t
            clicks: true,
            location: false,
            forms: true,
            scroll: true
        },
        injectChanges: true,
        logFileChanges: true,
        logLevel: 'debug',
        logPrefix: 'gulp-patterns',
        notify: true,
        reloadDelay: 0 //1000
    };
   
    browserSync(options);
}

function clean(path) {
    log('Cleaning :' + $.util.colors.blue(path));
    del(path);
}

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
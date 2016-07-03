var gulp = require('gulp');
var jshint = require('gulp-jshint');
var jscs = require('gulp-jscs');


gulp.task('vet', function () {
    console.log('Vet task');
    return gulp
    .src(['./scripts/app/client/*.js'])
    .pipe(jscs())
    .pipe(jshint())
    .pipe(jshint.reporter('jshint-stylish', { verbose: true }));
});
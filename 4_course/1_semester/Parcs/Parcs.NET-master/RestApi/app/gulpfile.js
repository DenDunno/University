var gulp = require('gulp');

var jshint = require('gulp-jshint');
/*
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var uglify = require('gulp-uglify');
*/
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var sass = require('gulp-sass');

gulp.task('bundle', function() {
    return browserify('./index.js')
        .bundle()
        //Pass desired output filename to vinyl-source-stream
        .pipe(source('bundle.js'))
        // Start piping stream to tasks!
        .pipe(gulp.dest('./'));
});

gulp.task('lint', function() {
    gulp.src('./js/*.js')
        .pipe(jshint())
        .pipe(jshint.reporter('default'));
});

gulp.task('sass', function () {
    gulp.src('./css/scss/index.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./css/'));
});

/*gulp.task('minify', function(){
    gulp.src('./src*//*.js')
        .pipe(concat('all.js'))
        .pipe(gulp.dest('./dist'))
        .pipe(rename('all.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('./dist'));
});*/

gulp.task('build', function(){
    gulp.run('lint', 'bundle', 'sass');
});

gulp.task('default', function(){
    gulp.run('build');

    // Отслеживаем изменения в файлах
    gulp.watch("./js", ['lint', 'bundle']);
    gulp.watch('./css/scss/main.scss', ['sass']);
});

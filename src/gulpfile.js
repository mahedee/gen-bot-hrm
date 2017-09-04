var path = require('path');
var gulp = require('gulp');
var plumber = require('gulp-plumber');
var msbuild = require("gulp-msbuild");
var iisexpress = require('gulp-serve-iis-express');
var browserSync = require('browser-sync').create();

var PORT = '3979';
var sources = [
    'HRMBot/Controllers/*.cs',
    'HRMBot/Helpers/*.cs',
    'HRMBot/ViewModel/**/*.cs',
    'HRMBot/Dialogs/*.cs'
];
var views = [
    'HRMBot/Views/**/*.cshtml',
];

gulp.task('default', ['server', 'build'], function() {
    browserSync.init({
        proxy: 'http://localhost:' + PORT,
        notify: false,
        ui: false
    });
    gulp.watch(sources, ['buildAndReload']);
    return gulp.watch(views, ['reload']);
});

gulp.task('reload', function() {
    browserSync.reload();
});

gulp.task('buildAndReload', ['build'], function(){
    return browserSync.reload();
});

gulp.task('build', function() {
    return gulp.src("HRMBot.sln")
        .pipe(plumber())
        .pipe(msbuild({
            toolsVersion: 'auto',
            logCommand: true
        }));
});

gulp.task('server', function() {
    var configPath = path.join(__dirname, '.vs\\config\\applicationhost.config');
    iisexpress({
        siteNames: ['HRMBot'],
        configFile: configPath,
        port: PORT
    });
});
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

toastr.options.extendedTimeOut = 3000;
toastr.options.timeOut = 3000;
toastr.options.closeButton = true;
toastr.options.positionClass = 'toast-bottom-right';

function onSubscribe() {

    toastr.info('Succeesfuly subscribed');
}
﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    $(".dropdown-menu  a").click(function () {
        var selText = $(this).text();
        console.log(selText);
        $('.dropdown-toggle').val(selText);
    });
});
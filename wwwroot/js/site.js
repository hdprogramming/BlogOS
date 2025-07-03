// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function loadProjects(sortBy) {
    $.ajax({
        url: '/Projects/GetSortedProjects',
        type: 'GET',
        data: { sortBy: sortBy },
        success: function (result) {
            $('#project-container').html(result);
        },
        error: function () {
            alert('Projeler yüklenirken bir hata oluştu.');
        }
    });
}

$(document).ready(function () {

    // Sayfa ilk açıldığında varsayılan projeleri yükle
    loadProjects('default');

    // dropdown-item'lara tıklanınca çalışacak
    $('#sortSelector .dropdown-item').on('click', function (e) {
        e.preventDefault(); // link davranışını engelle
        var sortBy = $(this).data('sort-by');
        loadProjects(sortBy);
    });

    // AJAX ile partial view yükleyen fonksiyon


});

$(document).ready(function () {
    // CSRF Token setup
   
    $.ajaxSetup({
        headers: {
            'RequestVerificationToken': $('meta[name="csrf-token"]').attr('content')
        }
    });
   function loadProjectsPartial() {
        $.get('/Projects/GetProjectsPartial', function (data) {
            $('#projectsContainer').html(data);
        });
    }

    $(document).ready(function () {
        loadProjectsPartial(); // Sayfa yüklendiğinde çek
    });
       window.openCreateModal = function () {
        resetForm();
        $('#projectModalLabel').text('Yeni Proje');
        panel.show();
    };

    const panel = new bootstrap.Offcanvas('#projectPanel');
window.openEditProject = function (id) {
    $.get('/Projects/Get/' + id, function (project) {
        openProjectPanel(project); // veriyi alıp forma gönderiyoruz
    }).fail(() => alert('Proje verisi alınırken hata oluştu.'));
}
window.openProjectPanel = function (projectData = null) {
    resetForm();
    if (projectData) {
        $('#Id').val(projectData.id);
        $('[name="Name"]').val(projectData.name);
        $('[name="Category"]').val(projectData.category);
        $('[name="Technologies"]').val(projectData.technologies);
        $('[name="Description"]').val(projectData.description);
        $('[name="Details"]').val(projectData.details);
        $('[name="CompletionDate"]').val(projectData.completionDate?.substring(0, 10));
        $('#projectPanelLabel').text("Projeyi Düzenle");
    } else {
        $('#projectPanelLabel').text("Yeni Proje");
    }
    panel.show();
}


    window.saveProject = function () {
    var formData = $('#projectForm').serialize();
    console.log(formData);
    $.ajax({
        url: '/Projects/Save',
        type: 'POST',
        data: formData,
        headers: {
            '_RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        },
        success: function () {
            panel.hide();
           loadProjectsPartial();
        },
        error: function () {
            alert('Proje kaydedilirken hata oluştu.');
        }
    });
};


    window.deleteProject = function (id) {
        if (confirm('Bu projeyi silmek istediğinize emin misiniz?')) {
            $.post('/Projects/Delete/' + id)
                .ok(function() {
                 loadProjectsPartial();
                })
                .fail(function () {
                    alert('Proje silinirken hata oluştu.');
                });
        }
    };

    function resetForm() {
        $('#projectForm')[0].reset();
       $('#Id').val('0');
       var today = new Date();
        var formatted = today.toISOString().substring(0, 10);
       $("input[name=CompletionDate]").val(formatted);
    }
    window.openEditProject = function (id) {
    $.get('/Projects/Get/' + id, function (data) {
        openProjectPanel(data);
    }).fail(() => alert('Proje verisi alınırken hata oluştu.'));
}
});

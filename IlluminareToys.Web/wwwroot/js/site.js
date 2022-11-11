// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
	$.busyLoadSetup({
		animation: "slide",
		background: "rgba(52, 58, 64, 0.86)"
    });

    $.fn.select2.defaults.set("theme", "bootstrap");
});

const showLoading = () => {
	$.busyLoadFull("show");
}

const hideLoading = () => {
	$.busyLoadFull("hide");

}

const showConfirmDialog = (title, text, callbackConfirm) => {
    Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirmar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            callbackConfirm()
        }
    })
}
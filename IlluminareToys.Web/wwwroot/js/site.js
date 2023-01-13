$(document).ready(function () {
	$.busyLoadSetup({
		animation: "slide",
		background: "rgba(52, 58, 64, 0.86)"
    });

/*    $.fn.select2.defaults.set("theme", "bootstrap");*/
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

const showMessage = (title, message, icon) => {
    Swal.fire({
        icon: icon,
        title: title,
        text: message,
    })
}
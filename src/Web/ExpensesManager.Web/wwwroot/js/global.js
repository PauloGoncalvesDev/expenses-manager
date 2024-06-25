$(document).ready(function () {
    $('.number-input').on('input', function () {
        var value = $(this).val();
        var newValue = value.replace(/[^\d,]/g, '');

        $(this).val(newValue);
    });
});

function showError(message) {
    var errorMessage = document.getElementById("error-message");
    errorMessage.textContent = message;
    errorMessage.style.display = "block";

    setTimeout(function () {
        errorMessage.classList.add('fade-out-up');
    }, 2000);

    errorMessage.addEventListener('animationend', function () {
        errorMessage.style.display = "none";
        errorMessage.classList.remove('fade-out-up');
    }, { once: true });
}

function showSuccess(message) {
    var successMessage = document.getElementById("success-message");
    successMessage.textContent = message;
    successMessage.style.display = "block";

    setTimeout(function () {
        successMessage.classList.add('fade-out-up');
    }, 2000);

    successMessage.addEventListener('animationend', function () {
        successMessage.style.display = "none";
        successMessage.classList.remove('fade-out-up');
    }, { once: true });
}
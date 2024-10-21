$(document).ready(function () {
    $('.number-input').on('input', function () {
        var value = $(this).val();
        var newValue = value.replace(/[^\d,]/g, '');

        $(this).val(newValue);
    });

    $('.moneyInput').mask('000.000,00', { reverse: true });

    $(".close-alert").click(function () {
        $('#error-message').hide('hide');
        $('#success-message').hide('hide');
    });

    phoneMask();
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

function getRandomColor() {
    const letters = '0123456789ABCDEF';
    let color = '#';

    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }

    return color;
}

function phoneMask() {
    $('#phoneInput').mask('(00) 00000-0000');
}
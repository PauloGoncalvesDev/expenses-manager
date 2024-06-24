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
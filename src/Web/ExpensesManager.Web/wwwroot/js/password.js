document.getElementById("passwordInput").addEventListener("input", function () {
    const password = this.value;
    validatePasswordCriteria(password);
});

document.getElementById("registrationForm").addEventListener("submit", function (event) {
    const password = document.getElementById("passwordInput").value;
    const confirmPassword = document.getElementById("confirmPasswordInput").value;

    if (password !== confirmPassword) {
        document.getElementById("passwordMatchHelpBlock").classList.remove("d-none");
        event.preventDefault();
    }
});

function validatePasswordCriteria(password) {
    const lengthCriteria = password.length >= 8;
    const uppercaseCriteria = /[A-Z]/.test(password);
    const lowercaseCriteria = /[a-z]/.test(password);
    const numberCriteria = /[0-9]/.test(password);
    const specialCharCriteria = /[@@$!%*?&.]/.test(password);

    updateCriteria("lengthCriteria", lengthCriteria);
    updateCriteria("uppercaseCriteria", uppercaseCriteria);
    updateCriteria("lowercaseCriteria", lowercaseCriteria);
    updateCriteria("numberCriteria", numberCriteria);
    updateCriteria("specialCharCriteria", specialCharCriteria);
}

function updateCriteria(criteriaId, isValid) {
    const criteriaElement = document.getElementById(criteriaId);
    if (isValid) {
        criteriaElement.classList.remove("text-danger");
        criteriaElement.classList.add("text-success");
    } else {
        criteriaElement.classList.remove("text-success");
        criteriaElement.classList.add("text-danger");
    }
}

document.getElementById("confirmPasswordInput").addEventListener("input", function () {
    const password = document.getElementById("passwordInput").value;
    const confirmPassword = document.getElementById("confirmPasswordInput").value;

    if (password === confirmPassword) {
        document.getElementById("passwordMatchHelpBlock").classList.add("d-none");
    }
    else
        document.getElementById("passwordMatchHelpBlock").classList.remove("d-none");
});
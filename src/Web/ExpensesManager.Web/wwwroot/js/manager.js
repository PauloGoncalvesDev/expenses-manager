document.querySelector(".firstForm").addEventListener("submit", function (event) {
    event.preventDefault();
    submitFirstForm();
});

function submitFirstForm() {
    var formData = new FormData(document.querySelector(".firstForm"));

    fetch('/Manager/AddCategory', {
        method: 'POST',
        body: formData,

    }).then(response => {
        if (response.ok)
            return response.json();

        showError('Erro no envio do formulário.');

    }).then(data => {
        if (data.success)
            showSecondForm();
        else 
            showError(data.error);

    }).catch(error => {
        showError(error);
    });
}

function showSecondForm() {
    var firstForm = document.querySelector(".firstForm");
    var secondForm = document.querySelector(".secondForm");

    firstForm.classList.add('slide-out-left-fade-out');
    secondForm.classList.add('slide-in-right-fade-in');

    firstForm.addEventListener('animationend', function () {
        firstForm.style.display = "none";
        secondForm.style.display = "block";
    }, { once: true });
}
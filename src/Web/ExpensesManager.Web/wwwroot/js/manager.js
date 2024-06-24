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

        throw new Error('Erro no envio do primeiro formulário.');

    }).then(data => {
        if (data.success)
            showSecondForm();
        else 
            alert('Erro ao processar o primeiro formulário.');

    }).catch(error => {
        console.log(error);
        alert('Erro ao processar o segundo formulário.');
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
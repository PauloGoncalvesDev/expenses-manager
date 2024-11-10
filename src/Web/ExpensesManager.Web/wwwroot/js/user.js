$(document).ready(function () {
    convertToBase64('#profilePicture', '#profilePictureInBase64');
});


function convertToBase64(inputSelector, base64OutputSelector) {
    $(inputSelector).on('change', function () {
        var input = this;
        var file = input.files[0];

        if (file) {
            var reader = new FileReader();

            reader.onload = function (e) {
                var base64Value = file.name + ',' + e.target.result;
                $(base64OutputSelector).val(base64Value);
            };

            reader.readAsDataURL(file);
        }
    });
}
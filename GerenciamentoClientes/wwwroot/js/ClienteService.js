var ClienteService = (function () {



});


$(document).ready(function () {
    $('#dataNascimentoInput').mask('00/00/0000', { placeholder: '__/__/____' });

    $('#CEP').mask('00000-000', { placeholder: '00000-000' }); 

    $('#Email').mask('A', {
        translation: {
            'A': { pattern: /[\w@\-.+]/, recursive: true }
        }
    });
});
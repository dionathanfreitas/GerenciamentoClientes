var ClienteService = (function () {
    var changePage = function (page) {
        page = parseInt(page);
        $('.page-item').removeClass('active');  
        $('.page-item').eq(page - 1).addClass('active');  
        $.ajax({
            url: '/Clientes/Index?page=' + page,
            type: 'GET',
            success: function (data) {
                // Encontrar o conteúdo da tabela na resposta
                var tableContent = $(data).find('#tableContent').html();

                // Atualizar apenas o conteúdo da tabela
                $('#tableContent').html(tableContent);
            },
            error: function () {
                alert("Erro ao carregar itens da página " + page);
            }
        });
    };


    var consultaCEP = function () {
        var cep = $('#CEP').val();
        if (cep) {
            $.ajax({
                url: 'https://viacep.com.br/ws/' + cep + '/json/',
                type: 'GET',
                success: function (data) {
                    $('#logradouro').text(' ' + (data.logradouro == undefined ? "Logradouro não encontrado!" : data.logradouro));
                    $('#bairro').text(' ' + (data.bairro == undefined ? "Bairro não encontrado!" : data.bairro));
                    $('#cidade').text(' ' + (data.localidade == undefined ? "Localidade não encontrada!" : data.localidade));
                    $('#estado').text(' ' + (data.uf == undefined ? "UF não encontrada!" : data.uf));
                },
                error: function () {
                    alert("Erro ao consultar o CEP");
                }
            });
        }
    }
    var filtrarClientes = function () {
        var filtroTipo = $('#filtroTipo').val();
        var filtroValor = $('#filtroValor').val();

        $.ajax({
            url: '/Clientes/Filtrar',
            type: 'GET',
            data: { tipo: filtroTipo, valor: filtroValor },
            success: function (data) {
                $('#tableContent').html(data);
            },
            error: function () {
                alert("Erro ao filtrar clientes");
            }
        });
    };


    return {
        ChangePage: changePage,
        ConsultaCEP: consultaCEP,
        FiltrarClientes: filtrarClientes
    };
})();

$(document).ready(function () {
    $('#dataNascimentoInput').mask('00/00/0000', { placeholder: '__/__/____' });

    $('#CEP').mask('00000-000', { placeholder: '00000-000' });

    $('#Email').mask('A', {
        translation: {
            'A': { pattern: /[\w@\-.+]/, recursive: true }
        }
    });

    $(document).on("click", ".pagination a.page-link", function (e) {
        e.preventDefault();
        var page = parseInt($(this).text());
        ClienteService.ChangePage(page);
    });

    $('#btnConsultaCEP').click(function (e) {
        e.preventDefault();
        ClienteService.ConsultaCEP();
    });

    $('#filtroValor').keypress(function (e) {
        if (e.which === 13) {
            ClienteService.FiltrarClientes();
        }
    });
    $('#btnFiltrar').click(function (e) {
        e.preventDefault();
        ClienteService.FiltrarClientes();
    });
});

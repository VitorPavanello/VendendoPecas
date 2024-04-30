$(document).ready(function () {
    $('#Vendas').DataTable({
        language:
        {
            "decimal": "",
            "emptyTable": "Sem dados disponíveis na tabela",
            "info": "Mostrando _START_ de _END_ em um total de _TOTAL_ registros",
            "infoEmpty": "Mostrando 0 de 0 em um total de 0 registros",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ registros",
            "loadingRecords": "Carregando...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "Nenhum registro correspondente encontrado",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Ordenar por esta coluna",
                "orderableReverse": "Ordem inversa desta coluna"
            }
        }
    });

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    }, 5000)

});
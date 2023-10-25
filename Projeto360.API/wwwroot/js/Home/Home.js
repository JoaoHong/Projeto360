var HomeAPI = function () {

	var urlAdicionar = "/Home/AdicionarProduto/";
	var urlIndex = "/Home/Index/";
	var tabelaProduto;

	var initTabela = function () {
		var table = $('#dataTable');
		// begin first table

		tabelaProduto = table.DataTable({
			responsive: true,


			// DOM Layout settings
			dom: `<'row'<'col-sm-12'tr>>
			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,


			lengthMenu: [5, 10, 25, 50],

			pageLength: 5,

			language: {
				"emptyTable": "Nenhum registro encontrado",
				"info": "Mostrando de _START_ at&eacute _END_ de _TOTAL_ registros",
				"infoEmpty": "Mostrando 0 at&eacute 0 de 0 registros",
				"infoFiltered": "(Filtrados de _MAX_ registros)",
				"infoThousands": ".",
				"CarregandoRecords": "Carregando...",
				"processing": "Processando...",
				"zeroRecords": "Nenhum registro encontrado",
				"search": "Pesquisar",
				"paginate": {
					"next": "Pr&oacuteximo",
					"previous": "Anterior",
					"first": "Primeiro",
					"last": "Último"
				},
				"aria": {
					"sortAscending": ": Ordenar colunas de forma ascendente",
					"sortDescending": ": Ordenar colunas de forma descendente"
				},
				"select": {
					"rows": {
						"_": "Selecionado %d linhas",
						"0": "Nenhuma linha selecionada",
						"1": "Selecionado 1 linha"
					},
					"1": "%d linha selecionada",
					"_": "%d linhas selecionadas",
					"cells": {
						"1": "1 c&eacutelula selecionada",
						"_": "%d c&eacutelulas selecionadas"
					},
					"columns": {
						"1": "1 coluna selecionada",
						"_": "%d colunas selecionadas"
					}
				},
				"buttons": {
					"copySuccess": {
						"1": "Uma linha copiada com sucesso",
						"_": "%d linhas copiadas com sucesso"
					},
					"collection": "Coleção  <span class=\"ui-button-icon-primary ui-icon ui-icon-triangle-1-s\"><\/span>",
					"colvis": "Visibilidade da Coluna",
					"colvisRestore": "Restaurar Visibilidade",
					"copy": "Copiar",
					"copyKeys": "Pressione ctrl ou u2318 + C para copiar os dados da tabela para a área de transferência do sistema. Para cancelar, clique nesta mensagem ou pressione Esc..",
					"copyTitle": "Copiar para a Área de Transferência",
					"csv": "CSV",
					"excel": "Excel",
					"pageLength": {
						"-1": "Mostrar todos os registros",
						"1": "Mostrar 1 registro",
						"_": "Mostrar %d registros"
					},
					"pdf": "PDF",
					"print": "Imprimir"
				},
				"autoFill": {
					"cancel": "Cancelar",
					"fill": "Preencher todas as c&eacutelulas com",
					"fillHorizontal": "Preencher c&eacutelulas horizontalmente",
					"fillVertical": "Preencher c&eacutelulas verticalmente"
				},
				"lengthMenu": "Exibir _MENU_ &nbsp;resultados",
				"searchBuilder": {
					"add": "Adicionar Condição",
					"button": {
						"0": "Construtor de Pesquisa",
						"_": "Construtor de Pesquisa (%d)"
					},
					"clearAll": "Limpar Tudo",
					"condition": "Condição",
					"conditions": {
						"date": {
							"after": "Depois",
							"before": "Antes",
							"between": "Entre",
							"empty": "Vazio",
							"equals": "Igual",
							"not": "Não",
							"notBetween": "Não Entre",
							"notEmpty": "Não Vazio"
						},
						"number": {
							"between": "Entre",
							"empty": "Vazio",
							"equals": "Igual",
							"gt": "Maior Que",
							"gte": "Maior ou Igual a",
							"lt": "Menor Que",
							"lte": "Menor ou Igual a",
							"not": "Não",
							"notBetween": "Não Entre",
							"notEmpty": "Não Vazio"
						},
						"string": {
							"contains": "Cont&eacutem",
							"empty": "Vazio",
							"endsWith": "Termina Com",
							"equals": "Igual",
							"not": "Não",
							"notEmpty": "Não Vazio",
							"startsWith": "Começa Com"
						},
						"array": {
							"contains": "Cont&eacutem",
							"empty": "Vazio",
							"equals": "Igual à",
							"not": "Não",
							"notEmpty": "Não vazio",
							"without": "Não possui"
						}
					},
					"data": "Data",
					"deleteTitle": "Excluir regra de filtragem",
					"logicAnd": "E",
					"logicOr": "Ou",
					"title": {
						"0": "Construtor de Pesquisa",
						"_": "Construtor de Pesquisa (%d)"
					},
					"value": "Valor"
				},
				"searchPanes": {
					"clearMessage": "Limpar Tudo",
					"collapse": {
						"0": "Pain&eacuteis de Pesquisa",
						"_": "Pain&eacuteis de Pesquisa (%d)"
					},
					"count": "{total}",
					"countFiltered": "{shown} ({total})",
					"emptyPanes": "Nenhum Painel de Pesquisa",
					"loadMessage": "Carregando Pain&eacuteis de Pesquisa...",
					"title": "Filtros Ativos"
				},
				"searchPlaceholder": "Digite um termo para pesquisar",
				"thousands": ".",
				"datetime": {
					"previous": "Anterior",
					"next": "Pr&oacuteximo",
					"hours": "Hora",
					"minutes": "Minuto",
					"seconds": "Segundo",
					"amPm": [
						"am",
						"pm"
					],
					"unknown": "-"
				},
				"editor": {
					"close": "Fechar",
					"create": {
						"button": "Novo",
						"submit": "Criar",
						"title": "Criar novo registro"
					},
					"edit": {
						"button": "Editar",
						"submit": "Atualizar",
						"title": "Editar registro"
					},
					"error": {
						"system": "Ocorreu um erro no sistema (<a target=\"\\\" rel=\"nofollow\" href=\"\\\">Mais informações<\/a>)."
					},
					"multi": {
						"noMulti": "Essa entrada pode ser editada individualmente, mas não como parte do grupo",
						"restore": "Desfazer alterações",
						"title": "Multiplos valores",
						"info": "Os itens selecionados contêm valores diferentes para esta entrada. Para editar e definir todos os itens para esta entrada com o mesmo valor, clique ou toque aqui, caso contrário, eles manterão seus valores individuais."
					},
					"remove": {
						"button": "Remover",
						"confirm": {
							"_": "Tem certeza que quer deletar %d linhas?",
							"1": "Tem certeza que quer deletar 1 linha?"
						},
						"submit": "Remover",
						"title": "Remover registro"
					}
				},
				"decimal": ","
			},

			// Order settings
			order: [[0, 'desc']],

			autoWidth: false,

			columnDefs: [
				{ responsivePriority: 1, targets: 1 },
				{ responsivePriority: 2, targets: -1 },
				{
					targets: 0,
					width: "500x",
					orderable: true,
				},
				{
					targets: 1,
					orderable: true,
				},
				{
					targets: 3,
					className: 'dt-left',
					orderable: true,
				},
				{
					targets: 4,
					orderable: true,
					className: "td-text-center",
				},
				{
					targets: -1,
					className: 'dt-center',
					width: "200px",
					orderable: false,
				}

			],
		});

	};

    var onClickAdicionarProduto = function () {
		$("#btnAdicionar").on("click", function () {
			debugger
			Swal.fire({
				title: 'Tem certeza?',
				html: 'Realmente deseja adicionar esse produto?',
				icon: "warning",
				confirmButtonText: "Sim",
				showCancelButton: true,
				cancelButtonText: "Não",
				customClass: {
					confirmButton: "btn font-weight-bold btn-primary",
					cancelButton: "btn font-weight-bold btn-secondary"
				}
			}).then(async function (result) {
				if (result.isConfirmed) {
					var model = {};
					model.Nome = $("#nomeProduto").val();
					model.Descricao = $("#descricaoProduto").val();
					model.Preco = parseFloat($("#valorProduto").val().replace(/[^0-9,]/g, '').replace(',', '.'));

					$.ajax({
						url: urlAdicionar,
						type: 'POST',
						contentType: 'application/json',
						data: JSON.stringify(model),

						success: function (retorno) {
							Swal.fire({
								title: retorno.title,
								html: retorno.message,
								icon: retorno.ok ? "success" : "error",
								confirmButtonText: "Ok",
								customClass: {
									confirmButton: "btn font-weight-bold btn-primary"
								}
							}).then(function () {
								if (retorno.ok) {
									window.location.href = urlIndex;								}
							})
						}
					})
				}
			})
		});
    }


    return {
		initIndex: function () {
			initTabela();
        },
		initAdcionar: function () {
			onClickAdicionarProduto();
			$("#valorProduto").maskMoney({
				prefix: "R$ ",
				decimal: ",",
				thousands: "."
			});
        },
        initEditar: function () {

        }
    }
}();
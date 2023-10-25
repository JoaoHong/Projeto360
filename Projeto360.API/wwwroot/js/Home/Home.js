var HomeAPI = function () {

	var urlAdicionar = "/Home/AdicionarProduto/";
	var urlIndex = "/Home/Index/";
	var urlEditar = "/Home/EditarProduto/";
	var urlDeletar = "/Home/DeletarProduto?Id="
	var tabelaProduto;

	var initTabela = function () {
		var table = $('#dataTable');
		// begin first table

		tabelaProduto = table.DataTable({
			responsive: true,
			searching: true,

			// DOM Layout settings
			dom: '<"top"f>rt<"bottom"lp><"clear">',


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

				"lengthMenu": "Exibir _MENU_ &nbsp;resultados",
			},

			// Order settings
			order: [[0, 'desc']],

			autoWidth: false,

			columnDefs: [
				{ responsivePriority: 1, targets: 1 },
				{ responsivePriority: 2, targets: -1 },
				{
					targets: 0,
					width: "20x",
					orderable: true,
				},
				{
					targets: 1,
					orderable: true,
					width: "300px"
				},
				{
					targets: 2,
					className: 'dt-left',
					orderable: false,
					width: "400px"
				},
				{
					targets: 3,
					className: 'dt-left',
					orderable: true,
					width: "130px"
				},
				{
					targets: 4,
					orderable: true,
					className: "td-text-center",
					width: "150px"
				},
				{
					targets: -1,
					className: 'dt-center',
					width: "100px",
					orderable: false,
				}

			],
		});

	};

    var onClickAdicionarProduto = function () {
		$("#btnAdicionar").on("click", function () {
			
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

	var onClickEditarProduto = function () {
		$("#btnEditar").on("click", function () {

			Swal.fire({
				title: 'Tem certeza?',
				html: 'Realmente deseja editar esse produto?',
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
					model.Id = $("#produtoId").val();
					model.Nome = $("#nomeProduto").val();
					model.Descricao = $("#descricaoProduto").val();
					model.Preco = parseFloat($("#valorProduto").val().replace(/[^0-9,]/g, '').replace(',', '.'));

					$.ajax({
						url: urlEditar,
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
									window.location.href = urlIndex;
								}
							})
						}
					})
				}
			})
		});
	}


	var onClickDeletarProduto = function () {
		$(".deletarProduto").on("click", function () {
			var id = $(this).attr("itemid");

			Swal.fire({
				title: 'Tem certeza?',
				html: 'Realmente deseja deletar esse produto?',
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


					$.ajax({
						url: urlDeletar + id,
						type: 'GET',

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
									window.location.href = urlIndex;
								}
							})
						}
					})
				}
			})
		})
	}
    return {
		initIndex: function () {
			initTabela();
			onClickDeletarProduto();
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
			onClickEditarProduto();
			$("#valorProduto").maskMoney({
				prefix: "R$ ",
				decimal: ",",
				thousands: "."
			});
        }
    }
}();
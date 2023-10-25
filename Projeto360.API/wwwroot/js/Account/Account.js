"use strict";

var AccountAPI = function () {

	var urlIndex = "/Home/Index/";
	var urlLogin = "/Account/Login/";
	var urlAcessar = "/Account/Acessar/";
	var urlAdicionar = "/Account/AdicionarUsuario/";
	var _LogInForm = function () {
		$('#confirmarLogin').on('click', function (e) {
			var model = {};
			model.Nome = $("#nome").val();
			model.Senha = $("#password").val();

			
			$.ajax({
				url: urlAcessar,
				type: 'POST',
				contentType: 'application/json',
				data: JSON.stringify(model),
				success: function (data) {

					if (data.ok) {
						window.location.href = urlIndex;
					}
					else {


						Swal.fire({
							title: data.title,
							html: data.message,
							icon: data.ok ? "success" : "error",
							confirmButtonText: "Ok",
							customClass: {
								confirmButton: "btn font-weight-bold btn-primary"
							}
						}).then(function () {
							
						});
					}

				},
				error: function () {



					Swal.fire({
						title: "Aviso",
						html: "Desculpe, houve um erro na requisição!",
						icon: "error",
						confirmButtonText: "Ok",
						customClass: {
							confirmButton: "btn font-weight-bold btn-primary"
						}
					}).then(function () {
						
					});

				}
			});
		});
	}

	var _CriarLoginForm = function () {
		$("#btnAdicionar").on("click", function () {
			Swal.fire({
				title: 'Tem certeza?',
				html: 'Realmente deseja adicionar esse usuario?',
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
					model.Nome = $("#nome").val();
					model.Senha = $("#senha").val();
					debugger
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
									window.location.href = urlLogin;
								}
							})
						}
					})
				}
			})
		});
	}
	return {
		initAdicionar: function () {
			_CriarLoginForm();
		},
		initLogIn: function () {
			_LogInForm();
		},

	};
}();

using Microsoft.EntityFrameworkCore;
using Projeto360.DAO.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Projeto360.DAO.Interface.IService;
using VascoVasconcellos.DAO.Service;
using Projeto360.DAO.Inteface.IRepository;
using Projeto360.DAO.Interface.IRepository;
using Projeto360.DAO.Repository;
using Microsoft.AspNetCore.Identity;
using Projeto360.DAO.IService;

namespace WebApplication1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region Services
			builder.Services.AddScoped<IServiceProduto, ServiceProduto>();
			builder.Services.AddScoped<IServiceUsuario, ServiceUsuario>();
			#endregion

			#region Repositories
			builder.Services.AddScoped<IRepositoryProduto, RepositoryProduto>();
			builder.Services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
			#endregion

			var configuration = new ConfigurationBuilder()
				.SetBasePath(builder.Environment.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.Build();

			var connectionString = configuration.GetConnectionString("DefaultConnection");


			builder.Services.AddDbContext<TesteDevContext>(options =>
	options.UseSqlServer(connectionString));


			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

			// Crie uma instância da configuração a partir do appsettings.json
			


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Login}/{id?}");

			app.Run();
		}
	}
}
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Models;
using ITSwarm.EntityFrameworkCore.Query.Internal;

namespace WebApp
{
	public class Startup
	{
		readonly IConfiguration _config;
		public Startup(IConfiguration config) => _config = config;
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationContext>(opitons =>
			{
				opitons.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
			});
			// services.AddSingleton<IMethodCallTranslator, SqlServerStringSplitFunctionTranslator>();
			services.AddMvc();
		}
		public void Configure(IApplicationBuilder app)
		{
			app.UseStaticFiles();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("home", "/", new { controller = "Home", action = "Index" });
				// endpoints.MapControllerRoute("residence-form-content", "home/residenceformcontent/{id}", new { controller = "Home", action = "ResidenceFormContent" });
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}

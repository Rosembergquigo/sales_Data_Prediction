using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using sales_data_prediction_back.DAO;
using sales_data_prediction_back.Models;
using sales_data_prediction_back.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sales_data_prediction_back
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//DBContext para consultas EntityFramework
			services.AddDbContext<StoreSampleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
			services.AddControllers();
			//Singleton de conexión a la base de datos para sentencias DML
			services.AddSingleton<AplicationDBContext>(provider =>
			{
				var configuration = provider.GetService<IConfiguration>();
				var connectionString = Configuration.GetConnectionString("DevConnection");
				return new AplicationDBContext(connectionString);
			});
			//Se registran los servicios segun tipo de Entidad 
			services.AddTransient<srvEmployee>();
			services.AddTransient<customerService>();
			services.AddTransient<ShipperService>();
			services.AddTransient<ProductService>();
			services.AddTransient<OrderService>();

			services.AddCors(options => {
				options.AddPolicy("newPolicy", app =>
				{
					app.AllowAnyOrigin()
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});
			;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors("newPolicy");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

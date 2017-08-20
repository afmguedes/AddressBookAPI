using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookAPI.Data;
using AddressBookAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AddressBookAPI {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services) {
			services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("AddressBookDB"));

			services.AddCors(options => options.AddPolicy("Cors", builder =>
			{
				builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));
			services.AddMvc();

			return services.BuildServiceProvider();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider) {
			app.UseCors("Cors");
			app.UseMvc();

			SeedData(serviceProvider.GetService<ApiContext>());
		}

		private static void SeedData(ApiContext context) {
			context.Contacts.Add(new ContactInfo()
			{
				Title = "Mr",
				FirstName = "Andre",
				Surname = "Guedes",
				Company = "Allocate",
				Address01 = "Flat 42, Whitgift House",
				Address02 = "61 Westbridge Road",
				Postcode = "SW11 3TH",
				Country = "United Kingdom",
				PersonalMobile = "07848064490",
				PersonalEmail = "afm.guedes@gmail.com"
			});

			context.Contacts.Add(new ContactInfo()
			{
				Title = "Mr",
				FirstName = "Graziano",
				Surname = "Cava",
				Company = "Gucci",
				Address01 = "Flat 5",
				Address02 = "Culvert Road",
				Postcode = "SW11 5AS",
				Country = "United Kingdom",
				PersonalMobile = "01231231212",
				PersonalEmail = "grax.cv@gmail.com"
			});

			context.SaveChanges();
		}
	}
}

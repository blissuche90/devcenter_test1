using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DevConatct.Data;
using DevConatct.Infrastructure;
using DevConatct.Model;
using DevContact.Domain;
using DevContact.Domain.Abstract;
using DevContact.Domain.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DevConatct
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
            services.AddDbContext<SQLDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SQLDbConnection")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            services.AddTransient<DataSeeder>();

            services.AddTransient<IDevContactRepository, DevContactRepository>();
            services.AddTransient<ICarRepository, CarRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.Configure<Settings>(options =>
            //{
            //    options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            //    options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            //});
        

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeeder seeder)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<SQLDBContext>().Database.Migrate();

                    seeder.SeedEveryThing();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

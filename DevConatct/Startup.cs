using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DevConatct.Data;
using DevConatct.Infrastructure;
using DevConatct.Model;
using DevContact.Domain;
using DevContact.Domain.Abstract;
using DevContact.Domain.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

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
            app.UseAuthentication();
            app.UseMvc(routes =>
            {


                //routes.MapRoute("pagination", "{area}/{controller}/Page{page}", new { action = "Index" });

                //routes.MapRoute("areaRoute", "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                //routes.MapRoute("jsonRoute", "{controller}/{action}.json", new { controller = "Home", action = "Index" });

                routes.MapRoute("default", "{controller=Developer}/{action=Get}/{id?}");

            });
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

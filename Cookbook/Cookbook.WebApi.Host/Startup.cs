using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.WebApi.BusinessLayer;
using Cookbook.WebApi.BusinessLayer.Interactors;
using Cookbook.WebApi.BusinessLayer.Repositories;
using Cookbook.WebApi.DataAccessLayer;
using Cookbook.WebApi.DataAccessLayer.DataContext;
using Cookbook.WebApi.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cookbook.WebApi.Host
{
    public class Startup
    {
        readonly string AllowCors = "AllowCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options => options.AddPolicy(AllowCors,
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .WithMethods("GET", "PUT", "POST", "DELETE")
                    .AllowAnyHeader();
                })
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<CookbookDbContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("Cookbook.Api.DBConnection")));
            services.AddScoped<ICookRepository, CookRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ICookInteractor, CookInteractor>();
            services.AddScoped<IIngredientInteractor, IngredientInteractor>();
            services.AddScoped<IRecipeInteractor, RecipeInteractor>();
            services.AddScoped<IPreparedRecipeRepository, PreparedRecipeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowCors);

            app.UseMvc();
        }
    }
}

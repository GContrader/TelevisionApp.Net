using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using ToDoApp.BusinessLayer.Mappers;
using ToDoApp.BusinessLayer.Services;
using ToDoApp.DataAccessLayer;

namespace ToDoApp.Api
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

            services.AddControllers();
            services.AddAutoMapper(new[]{
               typeof(ToDoMapperProfile).Assembly
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoApp", Version = "v1" });
            });

            services.AddScoped<ITodoService, ToDoService>();

            var connectionStringDb = Configuration["Database:localhost"];

            services.AddDbContext<TodoappContext>(options =>
            {
                options.UseSqlServer(connectionStringDb, providerOptions =>
                {
                    providerOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(1), null);
                    providerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoApp v1"));
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TodoappContext>();
                context.Database.Migrate();
            }

            app.UseRouting();

            app.UseSerilogRequestLogging();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

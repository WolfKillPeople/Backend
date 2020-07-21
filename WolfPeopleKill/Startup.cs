using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.DTO;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Repository;
using WolfPeopleKill.Services;

namespace WolfPeopleKill
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = $"Wolf API V1"
                });
                c.OrderActionsBy(o => o.RelativePath);
                c.IncludeXmlComments("../WolfPeopleKill/WolfPeopleKill.xml");
            });

            //services.AddDistributedMemoryCache();

            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(3000);
            //    options.Cookie.HttpOnly = true;
            //});
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://example.com")
                                             .AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });

            services.AddDbContext<WerewolfkillContext>(options =>
                options.UseSqlServer(Configuration["WerewolfkillConnection"]));

            services.AddScoped<IGameRepo, GameRepository>();
            services.AddScoped<IGameDTO, GameDTO>();
            services.AddScoped<IGameService, GameService>();

            services.AddScoped<IRoomService, RoomDBService>();
            services.AddScoped<IRoomDTO, RoomDTO>();
            services.AddScoped<IRoomRepo, RoomRepository>();

                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"API Doc");
            });

            app.UseRouting();
            app.UseAuthorization();
            //app.UseSession();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

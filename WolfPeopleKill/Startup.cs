using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Repository;
using WolfPeopleKill.Services;
using WolfPeopleKill.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure;
using Microsoft.Azure.Storage;

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
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("WerewolfkillConnection"));

            services.AddControllers();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMemoryCache();
#if DEBUG
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
#endif

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.IdleTimeout = TimeSpan.FromSeconds(3000);
                options.Cookie.Name = "RoomASPNETCore";
            });

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

            //services.AddDbContext<WerewolfkillContext>(options =>
                //options.UseSqlServer(Configuration.GetConnectionString("WerewolfkillConnection")));

            //services.AddDbContext<WerewolfkillContext>(options =>
            //    options.UseSqlServer(Configuration["WerewolfkillConnection"]));

            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameRepo, GameRepository>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepo, RoomRepository>();
            
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"API Doc");
            });
#endif
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

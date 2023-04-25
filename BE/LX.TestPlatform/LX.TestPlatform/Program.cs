using System.Text.Json.Serialization;
using LX.TestPlatform.Data;
using LX.TestPlatform.Entities;
using LX.TestPlatform.Interfaces;
using LX.TestPlatform.Repositories;
using LX.TestPlatform.Services.Implementation;
using LX.TestPlatform.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => 
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            
            app.UseCors("CorsPolicy");
            
            app.UseAuthorization();
            app.UseAuthentication();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
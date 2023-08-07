using Microsoft.OpenApi.Models;
using RestFulAPI_Legasuite.Application.Interface;
using RestFulAPI_Legasuite.Application.Services;
using RestFulAPI_Legasuite.Common.Configurations;
using RestFulAPI_Legasuite.Infrastructure.Context;
using RestFulAPI_Legasuite.Infrastructure.Interface;
using RestFulAPI_Legasuite.Infrastructure.Repository;
using RestFulAPI_Legasuite.Infrastructure;
using RestFulAPI_Legasuite.Application.Mapper;
using RestFulAPI_Legasuite.Common.Interface;

namespace RestFulAPI_Legasuite
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDatabaseContextFactory, DatabaseContextFactory>();
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddScoped<IDatabaseManager, DatabaseManager>();
            services.AddScoped<ILastPaidDetailsService, LastPaidDetailsService>();
            services.AddScoped<ILastPaidDetailsRepository, LastPaidDetailsRepository>();
            services.AddScoped<IReceiptDetailsService, ReceiptDetailsService>();
            services.AddScoped<IReceiptDetailsRepository, ReceiptDetailsRepository>();
            services.AddScoped<IUpdatePassword, UpdatePassword>();
            services.AddAutoMapper(cfg => cfg.AddProfile<TemplateProfile>(), AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(options => { options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestFulAPI_Legasuite", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestFulAPI_Legasuite v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

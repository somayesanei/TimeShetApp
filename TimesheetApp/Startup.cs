using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TimesheetApp.Context;
using TimesheetApp.Repository;
using TimesheetApp.Service;

namespace TimesheetApp
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<TimeSheetContext>(options =>
            options.UseSqlServer(_configuration["ConnectionStrings:SqlServer:ApplicationDbContextConnection"]));         
            
            services.AddScoped<IUnitOfWork, TimeSheetContext>();
            services.AddTransient<ITimeSheetService,TimeSheetService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITimeSheetRepository,TimeSheetRepository>();
          
            //services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)//, TimeSheetContext timeSheetContext)
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();           

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");               
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
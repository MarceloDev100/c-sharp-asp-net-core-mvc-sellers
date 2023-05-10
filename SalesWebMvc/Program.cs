using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace SalesWebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("SalesWebMvcContext");
            
            builder.Services.AddDbContext<SalesWebMvcContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ISeedingService, SeedingService>();
            builder.Services.AddScoped<ISellerService, SellerService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<ISalesRecordService, SalesRecordService>();
            
            var app = builder.Build();

            var enUs = new CultureInfo("en-Us");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUs),
                SupportedCultures = new List<CultureInfo> { enUs },
                SupportedUICultures = new List<CultureInfo> { enUs }
            };

            app.UseRequestLocalization(localizationOptions);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.  You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
                
            app.UseHttpsRedirection();

            SeedDataBase();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            void SeedDataBase()
            {
                using(var scope = app.Services.CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<ISeedingService>().Seed();
                }
            }
        }
    }
}
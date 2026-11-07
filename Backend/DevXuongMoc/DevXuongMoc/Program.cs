using DevXuongMoc.Data;
using DevXuongMoc.Repositories.Implementations;
using DevXuongMoc.Repositories.Interfaces;
using DevXuongMoc.Services.Implementations;
using DevXuongMoc.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevXuongMoc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // cấu hình
            var DbContext = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<XuongMocContext>(options => options.UseSqlServer(DbContext));

            builder.Services.AddScoped<IAspNetUserRepository, AspNetUserRepository>();
            builder.Services.AddScoped<IAspNetUserService, AspNetUserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapGet("/", () => Results.Redirect("/Admin"));

            app.Run();
        }
    }
}

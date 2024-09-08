using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Portal2.BLL.Mapping;
using Portal2.BLL.Service.implementation;
using Portal2.BLL.Service.Implementation;
using Portal2.BLL.Service.interfaces;
using Portal2.BLL.Service.Interfaces;
using Portal2.DAl.Repo.implementation;
using Portal2.DAl.Repo.interfaces;
using Portal2.pll.Models;
using Portal2.DAl.Entities;
using Portal2.DAl.DB;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
namespace Portal2.pll
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IEmployeeService1, EmployeeService1>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("name=DefaultConnection"));

            // Use AddIdentity to include role management
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                // Identity options here
                options.SignIn.RequireConfirmedAccount = false; // Adjust as per your needs
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                   options =>
                   {
                       options.LoginPath = new PathString("/Account/Register");
                       options.AccessDeniedPath = new PathString("/Account/Register");
                   });



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
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

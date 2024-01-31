using Employee_Details_Manage_Auto_BirthDay_Mail.Models;
using Employee_Details_Manage_Auto_BirthDay_Mail.Service;
using Microsoft.EntityFrameworkCore;

namespace Employee_Details_Manage_Auto_BirthDay_Mail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IEmployeeRepo,EmployeeRepoImplementation>();
            var b = builder.Configuration.GetConnectionString("Emp");
            builder.Services.AddDbContext<EmpDbContext>((op)=>op.UseSqlServer(b));

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
                name: "default",
                pattern: "{controller=Emp}/{action=Index}");

            app.Run();
        }
    }
}

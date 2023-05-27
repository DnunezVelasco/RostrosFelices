using Microsoft.EntityFrameworkCore;
using RostrosFelices.Data;

namespace RostrosFelices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<SumpermarketContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("RostrosFelices")
          ));


            builder.Services.AddAuthentication().AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.Name = "MyCookieAuth";
                options.LoginPath = "/Account/Register";
            });


            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
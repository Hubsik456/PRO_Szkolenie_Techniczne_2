using Back_End.DB;
using Microsoft.EntityFrameworkCore;

namespace PRO_Szkolenie_Techniczne_2_v2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<DB_Context>(options => options.UseSqlServer(@"Data Source=localhost;Initial Catalog=WIP_8;Integrated Security=True;Encrypt=False")); // Moje

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
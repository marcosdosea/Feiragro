using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace FeiragroWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ITipoProdutoService, TipoProdutoService>();
            builder.Services.AddTransient<IProdutoService, ProdutoService>();
            builder.Services.AddTransient<IPontoAssociacaoService, PontoAssociacaoService>();
            builder.Services.AddTransient<IFeiraService, FeiraService>();
          
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<FeiragroContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("FeiragroDatabase")!));

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
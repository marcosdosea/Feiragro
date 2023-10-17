using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace FeiragroAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IPessoaService, PessoaService>();
            builder.Services.AddTransient<IAssociacaoService, AssociacaoService>();
            builder.Services.AddTransient<IProdutoService, ProdutoService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<FeiragroContext>(
               options => options.UseMySQL(builder.Configuration.GetConnectionString("FeiragroDatabase")!));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
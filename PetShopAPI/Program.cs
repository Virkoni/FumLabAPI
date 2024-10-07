using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.OpenApi.Models;



namespace PetShopAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PetshopContext>(
                optionsAction: options => options.UseSqlServer(
                    connectionString: "Server=.;Database=petshop;TrustServerCertificate=True;Trusted_Connection=True"));
             
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();


            builder.Services.AddControllers();
     
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PetShop API",
                    Description = "описание.тхт",
                    Contact = new OpenApiContact
                    {
                        Name = "Пример контакта",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Пример лицензии",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

       
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

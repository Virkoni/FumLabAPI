
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Microsoft.OpenApi.Models;
using DataAccess.Wrapper.DataAccess.Wrapper;


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
            builder.Services.AddSwaggerGen();

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

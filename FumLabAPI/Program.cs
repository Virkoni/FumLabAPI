using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;



namespace FumLabAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<FumLabContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("DataAccess")));

            // holy shit 
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IArtistsService, ArtistsService>();
            builder.Services.AddScoped<ICartItemsService, CartItemsService>();
            builder.Services.AddScoped<ICartsService, CartsService>();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();
            builder.Services.AddScoped<ICustomPlushOrderPartsService, CustomPlushOrderPartsService>();
            builder.Services.AddScoped<ICustomPlushOrdersService, CustomPlushOrdersService>();
            builder.Services.AddScoped<IFilePermissionsService, FilePermissionsService>();
            builder.Services.AddScoped<IFilesService, FilesService>();
            builder.Services.AddScoped<IInventoryService, InventoryService>();
            builder.Services.AddScoped<IMessagesService, MessagesService>();
            builder.Services.AddScoped<IOrderItemsService, OrderItemsService>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();
            builder.Services.AddScoped<IPaymentMethodsService, PaymentMethodsService>();
            builder.Services.AddScoped<IPaymentsService, PaymentsService>();
            builder.Services.AddScoped<IPlushPartCategoriesService, PlushPartCategoriesService>();
            builder.Services.AddScoped<IPlushPartsService, PlushPartsService>();
            builder.Services.AddScoped<IProductArtistsService, ProductArtistsService>();
            builder.Services.AddScoped<IProductAvailabilityService, ProductAvailabilityService>();
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped<IReviewsService, ReviewsService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserRoleService, UserRoleService>();


            builder.Services.AddControllers();
     
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FumLab API",
                    Description = "��������.���",
                    Contact = new OpenApiContact
                    {
                        Name = "������ ��������",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "������ ��������",
                        Url = new Uri("https://tenor.com/bOu5d.gif")
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

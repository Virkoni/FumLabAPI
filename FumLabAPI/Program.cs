using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using FumLabAPI.Helpers;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FumLabAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("https://localhost:7049", "https://fumlabapi.onrender.com", "https://localhost:7053", "http://localhost:5057")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            // db
            builder.Services.AddDbContext<FumLabContext>(
                           options => options.UseSqlServer(builder.Configuration["ConnectionString"]));


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
            builder.Services.AddMapster();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FumLab API",
                    Description = "real",
                    Contact = new OpenApiContact
                    {
                        Name = "true",
                        Url = new Uri("https://localhost:7049/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "yep",
                        Url = new Uri("https://tenor.com/bOu5d.gif")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


            var app = builder.Build();

            //migrations
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<FumLabContext>();
                context.Database.Migrate();
            }


            // ??? if it works don't touch it
            // if (app.Environment.IsDevelopment())
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
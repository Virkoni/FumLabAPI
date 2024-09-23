using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;


    namespace Domain.Interfaces
    {
        public interface IRepositoryWrapper
        {
            IUserRepository User { get; }  
            IRoleRepository Role { get; }
            IUserRoleRepository UserRole { get; }
            ICategoriesRepository Category { get; }
            IProductsRepository Product { get; }
            IPetsRepository Pet { get; }
            IOrdersRepository Order { get; }
            IOrderItemsRepository OrderItem { get; }
            IFilesRepository File { get; }
            IFilePermissionsRepository FilePermission { get; }
            IMessagesRepository Message { get; }
            ISuppliersRepository Supplier { get; } 
            IProductSuppliersRepository ProductSupplier { get; } 
            IServiceRepository Service { get; }
            IAppointmentsRepository Appointment { get; }
            IInventoryRepository Inventory { get; }
            IPaymentMethodsRepository PaymentMethod { get; }
            IPaymentsRepository Payment { get; }
            IReviewsRepository Review { get; }
            IDiscountsRepository Discount { get; }
            IDiscountUsageRepository DiscountUsage { get; }
            IBreedsRepository Breed { get; }



        Task Save();
        }
    }



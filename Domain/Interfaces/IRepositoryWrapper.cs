using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        IUserRoleRepository UserRole { get; }
        ICategoriesRepository Category { get; }
        IProductsRepository Product { get; }
        IOrdersRepository Order { get; }
        IOrderItemsRepository OrderItem { get; }
        IFilesRepository File { get; }
        IFilePermissionsRepository FilePermission { get; }
        IMessagesRepository Message { get; }
        IInventoryRepository Inventory { get; }
        IPaymentMethodsRepository PaymentMethod { get; }
        IPaymentsRepository Payment { get; }
        IReviewsRepository Review { get; }

        IProductArtistsRepository ProductArtist { get; }
        ICartsRepository Cart { get; }
        ICartItemsRepository CartItem { get; }
        IPlushPartCategoriesRepository PlushPartCategory { get; }
        IPlushPartsRepository PlushPart { get; }
        ICustomPlushOrdersRepository CustomPlushOrder { get; }
        ICustomPlushOrderPartsRepository CustomPlushOrderPart { get; }
        IArtistsRepository Artist { get; }
        IProductAvailabilityRepository ProductAvailability { get; }

        Task Save();
    }
}
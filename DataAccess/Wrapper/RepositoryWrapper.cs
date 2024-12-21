using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FumLabContext _repoContext;

        private IUserRepository _user;
        private IRoleRepository _role;
        private IUserRoleRepository _userRole;
        private ICategoriesRepository _category;
        private IProductsRepository _product;
        private IOrdersRepository _order;
        private IOrderItemsRepository _orderItem;
        private IFilesRepository _file;
        private IFilePermissionsRepository _filePermission;
        private IMessagesRepository _message;
        private IInventoryRepository _inventory;
        private IPaymentMethodsRepository _paymentMethod;
        private IPaymentsRepository _payment;
        private IReviewsRepository _review;

        private IProductAvailabilityRepository _productAvailability;
        private IProductArtistsRepository _productArtist;
        private ICartsRepository _cart;
        private ICartItemsRepository _cartItem;
        private IPlushPartCategoriesRepository _plushPartCategory;
        private IPlushPartsRepository _plushPart;
        private ICustomPlushOrdersRepository _customPlushOrder;
        private ICustomPlushOrderPartsRepository _customPlushOrderPart;
        private IArtistsRepository _artist;




        public IUserRepository User
        {
            get
            {
                if (_user == null) { _user = new UserRepository(_repoContext); }
                return _user;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null) { _role = new RoleRepository(_repoContext); }

                return _role;
            }
        }

        public IUserRoleRepository UserRole
        {
            get
            {
                if (_userRole == null)

                {
                    _userRole = new UserRoleRepository(_repoContext);
                }

                return _userRole;
            }
        }
        public ICategoriesRepository Category
        {
            get
            {
                if (_category == null) { _category = new CategoriesRepository(_repoContext); }
                return _category;
            }
        }
        public IProductsRepository Product
        {
            get
            {
                if (_product == null) { _product = new ProductsRepository(_repoContext); }
                return _product;
            }
        }
        public IOrdersRepository Order
        {
            get
            {
                if (_order == null) { _order = new OrdersRepository(_repoContext); }
                return _order;
            }
        }
        public IOrderItemsRepository OrderItem
        {
            get
            {
                if (_orderItem == null) { _orderItem = new OrderItemsRepository(_repoContext); }
                return _orderItem;
            }
        }

        public IFilesRepository File
        {
            get
            {
                if (_file == null) { _file = new FilesRepository(_repoContext); }
                return _file;
            }
        }
        public IFilePermissionsRepository FilePermission
        {
            get
            {
                if (_filePermission == null) { _filePermission = new FilePermissionseRepository(_repoContext); }
                return _filePermission;
            }
        }
        public IMessagesRepository Message
        {
            get
            {
                if (_message == null) { _message = new MessagesRepository(_repoContext); }
                return _message;
            }
        }

        public IInventoryRepository Inventory
        {
            get
            {
                if (_inventory == null) { _inventory = new InventoryRepository(_repoContext); }
                return _inventory;
            }
        }

        public IPaymentMethodsRepository PaymentMethod
        {
            get
            {
                if (_paymentMethod == null) { _paymentMethod = new PaymentMethodsRepository(_repoContext); }
                return _paymentMethod;
            }
        }

        public IPaymentsRepository Payment
        {
            get
            {
                if (_payment == null) { _payment = new PaymentsRepository(_repoContext); }
                return _payment;
            }
        }

        public IReviewsRepository Review
        {
            get
            {
                if (_review == null) { _review = new ReviewsRepository(_repoContext); }
                return _review;
            }
        }


        public IProductArtistsRepository ProductArtist
        {
            get
            {
                if (_productArtist == null) { _productArtist = new ProductArtistsRepository(_repoContext); }
                return _productArtist;
            }
        }

        public ICartsRepository Cart
        {
            get
            {
                if (_cart == null) { _cart = new CartsRepository(_repoContext); }
                return _cart;
            }
        }

        public ICartItemsRepository CartItem
        {
            get
            {
                if (_cartItem == null) { _cartItem = new CartItemsRepository(_repoContext); }
                return _cartItem;
            }
        }

        public IPlushPartCategoriesRepository PlushPartCategory
        {
            get
            {
                if (_plushPartCategory == null) { _plushPartCategory = new PlushPartCategoriesRepository(_repoContext); }
                return _plushPartCategory;
            }
        }

        public IPlushPartsRepository PlushPart
        {
            get
            {
                if (_plushPart == null) { _plushPart = new PlushPartsRepository(_repoContext); }
                return _plushPart;
            }
        }

        public ICustomPlushOrdersRepository CustomPlushOrder
        {
            get
            {
                if (_customPlushOrder == null) { _customPlushOrder = new CustomPlushOrderRepository(_repoContext); }
                return _customPlushOrder;
            }
        }

        public ICustomPlushOrderPartsRepository CustomPlushOrderPart
        {
            get
            {
                if (_customPlushOrderPart == null) { _customPlushOrderPart = new CustomPlushOrderPartsRepository(_repoContext); }
                return _customPlushOrderPart;
            }
        }

        public IArtistsRepository Artist
        {
            get
            {
                if (_artist == null) { _artist = new ArtistsRepository(_repoContext); }
                return _artist;
            }
        }


        public IProductAvailabilityRepository ProductAvailability
        {
            get
            {
                if (_productAvailability == null) { _productAvailability = new ProductAvailabilityRepository(_repoContext); }
                return _productAvailability;
            }
        }


        public RepositoryWrapper(FumLabContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
using Domain.Interfaces;
using Domain.Models;
using DataAccess.Repositories;
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
        private PetshopContext _repoContext;

        private IUserRepository _user;
        private IRoleRepository _role;
        private IUserRoleRepository _userRole;

        private ICategoriesRepository _category;
        private IProductsRepository _product;
        private IPetsRepository _pet;
        private IOrdersRepository _order;
        private IOrderItemsRepository _orderItem;
        private IFilesRepository _file;
        private IFilePermissionsRepository _filePermission;
        private IMessagesRepository _message;
        private ISuppliersRepository _supplier;
        private IProductSuppliersRepository _productSupplier;
        private IServiceRepository _service;
        private IAppointmentsRepository _appointment;
        private IInventoryRepository _inventory;
        private IPaymentMethodsRepository _paymentMethod;
        private IPaymentsRepository _payment;
        private IReviewsRepository _review;
        private IDiscountsRepository _discount;
        private IDiscountUsageRepository _discountUsage; 
        private IBreedsRepository _breed;



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
                if (_role == null){ _role = new RoleRepository(_repoContext); }

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
        public IPetsRepository Pet
        {
            get
            {
                if (_pet == null) { _pet = new PetsRepository(_repoContext); }
                return _pet;
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
        public ISuppliersRepository Supplier
        {
            get
            {
                if (_supplier == null) { _supplier = new SuppliersRepository(_repoContext); }
                return _supplier;
            }
        }

        public IProductSuppliersRepository ProductSupplier
        {
            get
            {
                if (_productSupplier == null) { _productSupplier = new ProductSuppliersRepository(_repoContext); }
                return _productSupplier;
            }
        }

        public IServiceRepository Service
        {
            get
            {
                if (_service == null) { _service = new ServiceRepository(_repoContext); }
                return _service;
            }
        }

        public IAppointmentsRepository Appointment
        {
            get
            {
                if (_appointment == null) { _appointment = new AppointmentsRepository(_repoContext); }
                return _appointment;
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

        public IDiscountsRepository Discount
        {
            get
            {
                if (_discount == null) { _discount = new DiscountsRepository(_repoContext); }
                return _discount;
            }
        }

        public IDiscountUsageRepository DiscountUsage
        {
            get
            {
                if (_discountUsage == null) { _discountUsage = new DiscountUsageRepository(_repoContext); }
                return _discountUsage;
            }
        }
        public IBreedsRepository Breed
        {
            get
            {
                if (_breed == null) { _breed = new BreedsRepository(_repoContext); }
                return _breed;
            }
        }


        public RepositoryWrapper(PetshopContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        { 
            await _repoContext.SaveChangesAsync();
        }
    }
}

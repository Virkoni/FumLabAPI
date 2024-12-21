using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repositoryWrapper.Product.FindAll();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _repositoryWrapper.Product
                .FindByCondition(x => x.ProductId == id && x.IsDeleted == false);

            if (product is null || product.Count == 0)
            {
                throw new ArgumentNullException("Product not found");
            }

            return product.First();
        }

        public async Task Create(Product model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.ProductName))
            {
                throw new ArgumentException("Product name is required");
            }

            if (model.Price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero");
            }

            model.CreatedAt = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.Product.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Product model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingProduct = await _repositoryWrapper.Product
                .FindByCondition(x => x.ProductId == model.ProductId && x.IsDeleted == false);

            if (existingProduct is null || existingProduct.Count == 0)
            {
                throw new ArgumentNullException("Product not found");
            }

            model.UpdatedAt = DateTime.Now;
            _repositoryWrapper.Product.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var product = await _repositoryWrapper.Product
                .FindByCondition(x => x.ProductId == id && x.IsDeleted == false);

            if (product is null || product.Count == 0)
            {
                throw new ArgumentNullException("Product not found");
            }

            var productToDelete = product.First();
            productToDelete.IsDeleted = true;  // Soft delete
            productToDelete.UpdatedAt = DateTime.Now;

            _repositoryWrapper.Product.Update(productToDelete);
            _repositoryWrapper.Save();
        }
    }
}
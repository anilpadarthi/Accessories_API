using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            _productRepository = ProductRepository;
        }
        public async Task<IEnumerable<string>> CreateProductAsync(Product request)
        {
            _productRepository.Add(request);
            await _productRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Created successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetProductAsync(productId);
            product.IsActive = false;
            await _productRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Deleted successfully");
            return resultList;
        }

        public async Task<IEnumerable<string>> UpdateProductAsync(Product request)
        {
            var product = await _productRepository.GetProductAsync(request.ProductId);
            product.ProductName = request.ProductName;
            product.ProductCode = request.ProductCode;
            await _productRepository.SaveChangesAsync();
            List<string> resultList = new List<string>();
            resultList.Add("Updated successfully");
            return resultList;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _productRepository.GetProductAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetPagedProductsAsync(GetPagedRequest request)
        {
            return await _productRepository.GetPagedProductsAsync(request);
        }

        Task<IEnumerable<string>> IProductService.CreateProductPriceAsync(ProductPriceMap request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.UpdateProductPriceAsync(ProductPriceMap request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.DeleteProductPriceAsync(int productPriceId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductPriceMap>> IProductService.GetAllProductPricesAsync(int productId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.CreateProductBundleAsync(ProductBundleMap request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.UpdateProductBundleAsync(ProductBundleMap request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.DeleteProductBundleAsync(int productBundleId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductPriceMap>> IProductService.GetAllProductBundleAsync(int productId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.CreateProductSizeAsync(ProductSizeMap request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.UpdateProductSizeAsync(ProductSizeMap request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.DeleteProductSizeAsync(int productSizeId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductSizeMap>> IProductService.GetAllProductSizesAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.CreateProductColourAsync(ProductColourMap request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.UpdateProductColourAsync(ProductColourMap request)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> IProductService.DeleteProductColourAsync(int productColourId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductPriceMap>> IProductService.GetAllProductColoursAsync()
        {
            throw new NotImplementedException();
        }
    }
}

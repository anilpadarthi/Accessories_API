using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Business.Interfaces
{
    public interface IProductService
    {
        //Product
        Task<IEnumerable<string>> CreateProductAsync(Product request);
        Task<IEnumerable<string>> UpdateProductAsync(Product request);
        Task<IEnumerable<string>> DeleteProductAsync(int ProductId);
        Task<Product> GetProductAsync(int ProductId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetPagedProductsAsync(GetPagedRequest request);

        //Product Price
        Task<IEnumerable<string>> CreateProductPriceAsync(ProductPriceMap request);
        Task<IEnumerable<string>> UpdateProductPriceAsync(ProductPriceMap request);
        Task<IEnumerable<string>> DeleteProductPriceAsync(int productPriceId);
        Task<IEnumerable<ProductPriceMap>> GetAllProductPricesAsync(int productId);

        //Product Bundle
        Task<IEnumerable<string>> CreateProductBundleAsync(ProductBundleMap request);
        Task<IEnumerable<string>> UpdateProductBundleAsync(ProductBundleMap request);
        Task<IEnumerable<string>> DeleteProductBundleAsync(int productBundleId);
        Task<IEnumerable<ProductPriceMap>> GetAllProductBundleAsync(int productId);

        //Product Size
        Task<IEnumerable<string>> CreateProductSizeAsync(ProductSizeMap request);
        Task<IEnumerable<string>> UpdateProductSizeAsync(ProductSizeMap request);
        Task<IEnumerable<string>> DeleteProductSizeAsync(int productSizeId);
        Task<IEnumerable<ProductSizeMap>> GetAllProductSizesAsync();

        //Product Colour
        Task<IEnumerable<string>> CreateProductColourAsync(ProductColourMap request);
        Task<IEnumerable<string>> UpdateProductColourAsync(ProductColourMap request);
        Task<IEnumerable<string>> DeleteProductColourAsync(int productColourId);
        Task<IEnumerable<ProductPriceMap>> GetAllProductColoursAsync();
    }
}

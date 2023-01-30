using POS_Accessories.Models;
using POS_Accessories.Models.Request;
using POS_Accessories.Models.Response;

namespace POS_Accessories.Business.Interfaces
{
    public interface IProductService
    {
        //Product
        Task<CommonResponse> CreateAsync(Product request);
        Task<CommonResponse> UpdateAsync(Product request);
        Task<CommonResponse> UpdateStatusAsync(int id, string status);
        Task<CommonResponse> GetByIdAsync(int id);
        Task<CommonResponse> GetAllAsync();
        Task<CommonResponse> GetByPagingAsync(GetPagedRequest request);

        ////Product Price
        //Task<CommonResponse> CreateProductPriceAsync(ProductPriceMap request);
        //Task<CommonResponse> UpdateProductPriceAsync(ProductPriceMap request);
        //Task<CommonResponse> DeleteProductPriceAsync(int productPriceId);
        //Task<CommonResponse> GetAllProductPricesAsync(int productId);

        ////Product Bundle
        //Task<CommonResponse> CreateProductBundleAsync(ProductBundleMap request);
        //Task<CommonResponse> UpdateProductBundleAsync(ProductBundleMap request);
        //Task<CommonResponse> DeleteProductBundleAsync(int productBundleId);
        //Task<CommonResponse> GetAllProductBundleAsync(int productId);

        ////Product Size
        //Task<CommonResponse> CreateProductSizeAsync(ProductSizeMap request);
        //Task<CommonResponse> UpdateProductSizeAsync(ProductSizeMap request);
        //Task<CommonResponse> DeleteProductSizeAsync(int productSizeId);
        //Task<CommonResponse> GetAllProductSizesAsync();

        ////Product Colour
        //Task<CommonResponse> CreateProductColourAsync(ProductColourMap request);
        //Task<CommonResponse> UpdateProductColourAsync(ProductColourMap request);
        //Task<CommonResponse> DeleteProductColourAsync(int productColourId);
        //Task<CommonResponse> GetAllProductColoursAsync();
    }
}

using ItemShop.Catalog.DTOs.ProductImageDTOs;

namespace ItemShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageasync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImage(string id);
    }
}
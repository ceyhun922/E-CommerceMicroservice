using ItemShop.Catalog.DTOs.ProductDTOs;

namespace ItemShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task RemoveProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
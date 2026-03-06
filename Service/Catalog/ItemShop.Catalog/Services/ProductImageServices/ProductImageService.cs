using AutoMapper;
using ItemShop.Catalog.DTOs.ProductImageDTOs;
using ItemShop.Catalog.Entities;
using ItemShop.Catalog.Settings;
using MongoDB.Driver;

namespace ItemShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client =new MongoClient(_databaseSettings.ConnectionString);
            var database =client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection =database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value =_mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageasync(string id)
        {
           await _productImageCollection.DeleteOneAsync(x=>x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
           var values =await _productImageCollection.Find(x=>true).ToListAsync();
           return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImage(string id)
        {
           var values =await _productImageCollection.Find(x=>x.ProductImageId ==id).FirstOrDefaultAsync();
           return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x=>x.ProductImageId ==updateProductImageDto.ProductImageId,value);
        }
    }
}
using AutoMapper;
using ItemShop.Catalog.DTOs.ProductDetailDTOs;
using ItemShop.Catalog.Entities;
using ItemShop.Catalog.Settings;
using MongoDB.Driver;

namespace ItemShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _collectionProductDetail;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _collectionProductDetail = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _collectionProductDetail.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _collectionProductDetail.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var value =await _collectionProductDetail.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(value);

        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetail(string id)
        {
            var value =await _collectionProductDetail.Find(x=>x.ProductDetailId ==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value =_mapper.Map<ProductDetail>(updateProductDetailDto);
            await _collectionProductDetail.FindOneAndReplaceAsync(x=>x.ProductDetailId == updateProductDetailDto.ProductDetailId,value);

        }
    }
}
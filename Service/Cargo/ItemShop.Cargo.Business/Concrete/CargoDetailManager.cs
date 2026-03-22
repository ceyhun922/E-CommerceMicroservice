using System.Linq.Expressions;
using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.DAL.Abstracts;
using ItemShop.Cargo.Entity.Concrete;

namespace ItemShop.Cargo.Business.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDAL _cargoDetail;

        public CargoDetailManager(ICargoDetailDAL cargoDetail)
        {
            _cargoDetail = cargoDetail;
        }

        public async Task DeleteServiceAsync(int id)
        {
           await _cargoDetail.DeleteAsync(id);
        }

        public async Task<List<CargoDetail>> GetAllServiceAsync()
        {
           return await _cargoDetail.GetAllAsync();
        }

        public async Task<List<CargoDetail>> GetAllServiceFilterAsync(Expression<Func<CargoDetail, bool>> filter)
        {
             return await _cargoDetail.GetAllFilterAsync(filter);
        }

        public async Task<CargoDetail> GetByIdServiceAsync(int id)
        {
           return await _cargoDetail.GetByIdAsync(x=>x.CargoDetailId ==id);
        }

        public async Task InsertServiceAsync(CargoDetail entity)
        {
           await _cargoDetail.InsertAsync(entity);
        }

        public async Task UpdateServiceAsync(CargoDetail entity)
        {
             await _cargoDetail.UpdateAsync(entity);
        }
    }
}
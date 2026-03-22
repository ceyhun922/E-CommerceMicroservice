using System.Linq.Expressions;
using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.DAL.Abstracts;
using ItemShop.Cargo.Entity.Concrete;

namespace ItemShop.Cargo.Business.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    
    {
        private readonly ICargoOperationDAL _cargoOperation;

        public CargoOperationManager(ICargoOperationDAL cargoOperation)
        {
            _cargoOperation = cargoOperation;
        }

        public async Task DeleteServiceAsync(int id)
        {
           await _cargoOperation.DeleteAsync(id);
        }

        public async Task<List<CargoOperation>> GetAllServiceAsync()
        {
           return await _cargoOperation.GetAllAsync();
        }

        public async Task<List<CargoOperation>> GetAllServiceFilterAsync(Expression<Func<CargoOperation, bool>> filter)
        {
             return await _cargoOperation.GetAllFilterAsync(filter);
        }

        public async Task<CargoOperation> GetByIdServiceAsync(int id)
        {
           return await _cargoOperation.GetByIdAsync(x=>x.CargoOperationId ==id);
        }

        public async Task InsertServiceAsync(CargoOperation entity)
        {
           await _cargoOperation.InsertAsync(entity);
        }

        public async Task UpdateServiceAsync(CargoOperation entity)
        {
             await _cargoOperation.UpdateAsync(entity);
        }
    }
}
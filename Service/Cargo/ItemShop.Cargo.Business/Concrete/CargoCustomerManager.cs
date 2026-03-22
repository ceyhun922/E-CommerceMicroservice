using System.Linq.Expressions;
using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.DAL.Abstracts;
using ItemShop.Cargo.Entity.Concrete;

namespace ItemShop.Cargo.Business.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDAL _cargoCustomer;

        public CargoCustomerManager(ICargoCustomerDAL cargoCustomer)
        {
            _cargoCustomer = cargoCustomer;
        }

        public async Task DeleteServiceAsync(int id)
        {
           await _cargoCustomer.DeleteAsync(id);
        }

        public async Task<List<CargoCustomer>> GetAllServiceAsync()
        {
           return await _cargoCustomer.GetAllAsync();
        }

        public async Task<List<CargoCustomer>> GetAllServiceFilterAsync(Expression<Func<CargoCustomer, bool>> filter)
        {
             return await _cargoCustomer.GetAllFilterAsync(filter);
        }

        public async Task<CargoCustomer> GetByIdServiceAsync(int id)
        {
           return await _cargoCustomer.GetByIdAsync(x=>x.CargoCustomerId ==id);
        }

        public async Task InsertServiceAsync(CargoCustomer entity)
        {
           await _cargoCustomer.InsertAsync(entity);
        }

        public async Task UpdateServiceAsync(CargoCustomer entity)
        {
             await _cargoCustomer.UpdateAsync(entity);
        }
    }
}
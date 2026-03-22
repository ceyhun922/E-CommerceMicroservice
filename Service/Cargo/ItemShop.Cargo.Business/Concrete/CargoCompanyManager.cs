using System.Linq.Expressions;
using ItemShop.Cargo.Business.Abstract;
using ItemShop.Cargo.DAL.Abstracts;
using ItemShop.Cargo.Entity.Concrete;

namespace ItemShop.Cargo.Business.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDAL _cargoCompany;

        public CargoCompanyManager(ICargoCompanyDAL cargoCompany)
        {
            _cargoCompany = cargoCompany;
        }

        public async Task DeleteServiceAsync(int id)
        {
           await _cargoCompany.DeleteAsync(id);
        }

        public async Task<List<CargoCompany>> GetAllServiceAsync()
        {
           return await _cargoCompany.GetAllAsync();
        }

        public async Task<List<CargoCompany>> GetAllServiceFilterAsync(Expression<Func<CargoCompany, bool>> filter)
        {
             return await _cargoCompany.GetAllFilterAsync(filter);
        }

        public async Task<CargoCompany> GetByIdServiceAsync(int id)
        {
           return await _cargoCompany.GetByIdAsync(x=>x.CargoCompanyId ==id);
        }

        public async Task InsertServiceAsync(CargoCompany entity)
        {
           await _cargoCompany.InsertAsync(entity);
        }

        public async Task UpdateServiceAsync(CargoCompany entity)
        {
             await _cargoCompany.UpdateAsync(entity);
        }
    }
}
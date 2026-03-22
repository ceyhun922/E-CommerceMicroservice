using ItemShop.Cargo.DAL.Abstracts;
using ItemShop.Cargo.DAL.Concrete;
using ItemShop.Cargo.DAL.Repositories;
using ItemShop.Cargo.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ItemShop.Cargo.DAL.EntityFramework
{
    public class EFCargoCompoanyRepository : GenericRepository<CargoCompany>, ICargoCompanyDAL
    {
        public EFCargoCompoanyRepository(CargoContext context) : base(context)
        {
        }
    }
}

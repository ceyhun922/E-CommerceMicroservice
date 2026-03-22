using ItemShop.Cargo.DAL.Abstracts;
using ItemShop.Cargo.DAL.Concrete;
using ItemShop.Cargo.DAL.Repositories;
using ItemShop.Cargo.Entity.Concrete;

namespace ItemShop.Cargo.DAL.EntityFramework
{
    public class EfCargoOperationRepository : GenericRepository<CargoOperation>, ICargoOperationDAL
    {
        public EfCargoOperationRepository(CargoContext context) : base(context)
        {
        }
    }
}
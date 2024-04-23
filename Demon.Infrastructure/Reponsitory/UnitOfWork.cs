using Demon.Application.Common.Interfaces;
using Demon.Infrastructure.Data;

namespace Demon.Infrastructure.Reponsitory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IVillaReponsitory Villa { get; private set; }

        public IVillaNumberReponsitory VillaNumber { get; private set; }
        public IAmenityReponsitory Amenity { get; private set; }
        public IApplicationUserRepository User { get; private set; }

        public IBooking Booking { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Villa = new VillaReponsitory(_db);
            VillaNumber = new VillaNumberReponsitory(_db);
            Amenity = new AmenityReponsitory(_db);
            User = new ApplicationUserRepository(_db);
            Booking = new BookingReponsitory(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

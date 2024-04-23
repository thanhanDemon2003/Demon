using Demon.Application.Common.Interfaces;
using Demon.Domain.Entities;
using Demon.Infrastructure.Data;

namespace Demon.Infrastructure.Reponsitory
{
    public class VillaNumberReponsitory(ApplicationDbContext db) : Repository<VillaNumber>(db), IVillaNumberReponsitory
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(VillaNumber entity)
        {
            _db.Update(entity);

        }
    }
}

using Demon.Application.Common.Interfaces;
using Demon.Domain.Entities;
using Demon.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.Infrastructure.Reponsitory
{
    public class AmenityReponsitory : Repository<Amenity>, IAmenityReponsitory
    {
        private readonly ApplicationDbContext _db;
        public AmenityReponsitory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Amenity entity)
        {
            _db.Update(entity);
        }
    }
}

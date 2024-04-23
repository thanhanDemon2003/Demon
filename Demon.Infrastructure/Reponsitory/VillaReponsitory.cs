using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demon.Application.Common.Interfaces;
using Demon.Domain.Entities;
using Demon.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Demon.Infrastructure.Reponsitory
{
    public class VillaReponsitory(ApplicationDbContext db) : Repository<Villa>(db), IVillaReponsitory
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(Villa entity)
        {
            _db.Update(entity);
        }
    }
}

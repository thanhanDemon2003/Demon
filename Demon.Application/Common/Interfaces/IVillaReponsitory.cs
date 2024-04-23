using Demon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demon.Application.Common.Interfaces
{
    public interface IVillaReponsitory : IRepository<Villa>
    {

        void Update(Villa entity);

    }
}

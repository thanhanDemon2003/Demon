using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IVillaReponsitory Villa { get; }
        IVillaNumberReponsitory VillaNumber { get; }
        IAmenityReponsitory Amenity { get; }
        IBooking Booking { get; }
        IApplicationUserRepository User { get; }
        void Save();
    }
}

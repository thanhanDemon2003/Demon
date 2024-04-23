using Demon.Domain.Entities;

namespace Demon.Application.Common.Interfaces
{
    public interface IVillaNumberReponsitory : IRepository<VillaNumber>
    {
        void Update(VillaNumber entity);

    }
}

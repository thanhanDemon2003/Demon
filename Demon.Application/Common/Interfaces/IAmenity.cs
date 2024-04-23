﻿using Demon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.Application.Common.Interfaces
{
    public interface IAmenityReponsitory : IRepository<Amenity>
    {
        public void Update(Amenity entity);
    }
}

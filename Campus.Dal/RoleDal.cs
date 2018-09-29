using Campus.DalInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.Dal
{
    public class RoleDal : IRoleDal
    {
        private readonly CampusDbContext _campusDbContext;

        public RoleDal(CampusDbContext campusDbContext)
        {
            _campusDbContext = campusDbContext;
        }
    }
}

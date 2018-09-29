using Campus.BllInterface;
using Campus.DalInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Bll
{
    public class RoleBll : IRoleBll
    {
        private readonly IRoleDal _roleDal;

        public RoleBll(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
    }
}

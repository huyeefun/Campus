using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.BllInterface
{
    public interface IUserBll
    {
        bool InsertUser(User user);
    }
}

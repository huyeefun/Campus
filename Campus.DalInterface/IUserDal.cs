﻿using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.DalInterface
{
    public interface IUserDal
    {
        bool InsertUser(User user);
        int GetRoleIdFormName(string name);
        bool ValidLogin(User loginUser);
        int GetRoleIdFormUName(string userName);
        int GetIdByUName(string userName);
        bool ExistUserName(string userName);
    }
}

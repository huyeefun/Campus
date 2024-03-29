﻿using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Campus.BllInterface
{
    public interface IUserBll
    {
        bool InsertUser(User user, bool isTeacher);
        int GetRoleIdFormName(string name);
        bool ValidLogin(User loginUser);
        int GetRoleIdFormUName(string userName);
        int GetIdByUName(string userName);
        bool ExistUserName(string userName);
    }
}

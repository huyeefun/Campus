﻿using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.DalInterface
{
    public interface IUserDal
    {
         bool InsertUser(User user);
    }
}
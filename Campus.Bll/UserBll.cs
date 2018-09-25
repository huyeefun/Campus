using Campus.BllInterface;
using Campus.DalInterface;
using Campus.Domain;
using Campus.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Bll
{
    public class UserBll : IUserBll
    {
        private readonly IUserDal _userDal;


        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool InsertUser(User user)
        {
            user.Password = MD5Hash.Create(user.Password);
            return _userDal.InsertUser(user);
        }
    }
}

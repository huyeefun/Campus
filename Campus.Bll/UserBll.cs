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

        public bool InsertUser(User user, bool isTeacher)
        {
            user.Password = MD5Hash.Create(user.Password);
            if (isTeacher)
            {
                user.RoleId = _userDal.GetRoleIdFormName("老师");
            }
            else
            {
                user.RoleId = _userDal.GetRoleIdFormName("学生");
            }
            return _userDal.InsertUser(user);
        }

        public int GetRoleIdFormName(string name)
        {
            return _userDal.GetRoleIdFormName(name);
        }

        public bool ValidLogin(User loginUser)
        {
            loginUser.Password = MD5Hash.Create(loginUser.Password);
            return _userDal.ValidLogin(loginUser);
        }

        public int GetRoleIdFormUName(string userName)
        {
           return _userDal.GetRoleIdFormUName(userName);
        }

        public int GetIdByUName(string userName)
        {
            return _userDal.GetIdByUName(userName);
        }
    }
}

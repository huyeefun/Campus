using Campus.DalInterface;
using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Dal
{
    public class UserDal : IUserDal
    {
        private CampusDbContext _campusDbContext;

        public UserDal(CampusDbContext campusDbContext)
        {
            _campusDbContext = campusDbContext;
        }

        public bool InsertUser(User user)
        {
            _campusDbContext.Users.Add(user);
            int rows = _campusDbContext.SaveChanges();
            return rows > 0;
        }
    }
}

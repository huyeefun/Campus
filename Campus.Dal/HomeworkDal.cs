using Campus.DalInterface;
using Campus.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.Dal
{
    public class HomeworkDal : IHomeworkDal
    {
        private readonly CampusDbContext _campusDbContext;

        public HomeworkDal(CampusDbContext campusDbContext)
        {
            _campusDbContext = campusDbContext;
        }

        public PagedList<Homework> GetAllHomeworks(int pageIndex, int pageSize)
        {

            var list = _campusDbContext.Homeworks.Include(x => x.User)
                .OrderByDescending(x => x.ReleaseTime)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var count = _campusDbContext.Homeworks.Count();
            return new PagedList<Homework>(list, count);
        }

        public bool Insert(Homework homework)
        {
            _campusDbContext.Homeworks.Add(homework);
            int rows = _campusDbContext.SaveChanges();
            return rows > 0;
        }
    }
}

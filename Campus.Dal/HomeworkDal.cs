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

        public bool Delete(Homework homework)
        {
            _campusDbContext.Homeworks.Update(homework);
            int rows = _campusDbContext.SaveChanges();
            return rows > 0;
        }

        public PagedList<Homework> GetAllHomeworks(int pageIndex, int pageSize)
        {

            var list = _campusDbContext.Homeworks.Include(x => x.User)
                .OrderByDescending(x => x.ReleaseTime).Where(x => x.Deleted == false)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var count = _campusDbContext.Homeworks.Where(x => x.Deleted == false).Count();
            return new PagedList<Homework>(list, count);
        }

        public Homework GetDetail(int id)
        {
            var homework = _campusDbContext.Homeworks.Where(x => x.Id == id).FirstOrDefault();
            homework.Answers = _campusDbContext.Answers.Include(x => x.User).Where(x => x.HomeworkId == id).ToList();
            return homework;
        }

        public bool Insert(Homework homework)
        {
            _campusDbContext.Homeworks.Add(homework);
            int rows = _campusDbContext.SaveChanges();
            return rows > 0;
        }

        public bool Update(Homework homework)
        {
            _campusDbContext.Homeworks.Update(homework);
            int rows = _campusDbContext.SaveChanges();
            return rows > 0;
        }
    }
}

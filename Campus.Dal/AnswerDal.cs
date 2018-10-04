using Campus.DalInterface;
using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.Dal
{
    public class AnswerDal : IAnswerDal
    {
        private readonly CampusDbContext _campusDbContext;

        public AnswerDal(CampusDbContext campusDbContext)
        {
            _campusDbContext = campusDbContext;
        }

        public Answer GetDetail(int id)
        {
           return _campusDbContext.Answers.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Insert(Answer answer)
        {
            _campusDbContext.Answers.Add(answer);
            int rows= _campusDbContext.SaveChanges();
            return rows > 0;
        }

        public bool Update(Answer answer)
        {
            _campusDbContext.Answers.Update(answer);
            int rows = _campusDbContext.SaveChanges();
            return rows > 0;
        }

        public bool Delete(Answer answer)
        {
            _campusDbContext.Answers.Update(answer);
            int rows = _campusDbContext.SaveChanges();
            return rows > 0;
        }
    }
}

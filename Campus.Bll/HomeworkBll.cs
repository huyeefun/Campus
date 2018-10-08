using Campus.BllInterface;
using Campus.DalInterface;
using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Bll
{
    public class HomeworkBll : IHomeworkBll
    {
        private readonly IHomeworkDal _homeworkDal;

        public HomeworkBll(IHomeworkDal homeworkDal)
        {
            _homeworkDal = homeworkDal;
        }

        public PagedList<Homework> GetAllHomeworks(int pageIndex, int pageSize)
        {
            return _homeworkDal.GetAllHomeworks(pageIndex, pageSize);
        }

        public Homework GetDetail(int id)
        {
            return _homeworkDal.GetDetail(id);
        }

        public bool Insert(Homework homework)
        {
            return _homeworkDal.Insert(homework);
        }

        public bool Update(Homework homework)
        {
            homework.ReleaseTime = DateTime.Now;
            return _homeworkDal.Update(homework);
        }

        public bool Delete(Homework homework)
        {
            return _homeworkDal.Delete(homework);
        }
    }
}

using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.BllInterface
{
    public interface IHomeworkBll
    {
        bool Insert(Homework homework);
        PagedList<Homework> GetAllHomeworks(int pageIndex, int pageSize);
        Homework GetDetail(int id);
        bool Update(Homework homework);
        bool Delete(Homework homework);
    }
}

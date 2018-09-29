using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.DalInterface
{
    public interface IHomeworkDal
    {
        bool Insert(Homework homework);
        PagedList<Homework> GetAllHomeworks(int pageIndex,int pageSize);
    }
}

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
    }
}

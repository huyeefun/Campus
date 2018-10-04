using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.DalInterface
{
    public interface IAnswerDal
    {
        bool Insert(Answer answer);
        Answer GetDetail(int id);
        bool Update(Answer answer);
        bool Delete(Answer answer);
    }
}

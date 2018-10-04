using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.BllInterface
{
    public interface IAnswerBll
    {
        bool Insert(Answer answer);
        Answer GetDetail(int id);
        bool Update(Answer answer);
        bool Delete(int answerId);
    }
}

using Campus.BllInterface;
using Campus.DalInterface;
using Campus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Bll
{
    public class AnswerBll : IAnswerBll
    {
        private readonly IAnswerDal _answerDal;

        public AnswerBll(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }

        public Answer GetDetail(int id)
        {
            return _answerDal.GetDetail(id);
        }

        public bool Insert(Answer answer)
        {
            answer.ReleaseTime = DateTime.Now;
            answer.Deleted = false;
            return _answerDal.Insert(answer);
        }

        public bool Update(Answer answer)
        {
            answer.ReleaseTime = DateTime.Now;
            return _answerDal.Update(answer);
        }

        public bool Delete(int answerId)
        {
            Answer answer = _answerDal.GetDetail(answerId);
            answer.Deleted = true;
            return _answerDal.Delete(answer);
        }
    }
}

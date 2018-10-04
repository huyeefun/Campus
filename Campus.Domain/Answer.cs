using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Domain
{
    public class Answer
    {
        public int Id { get; set; }
        public int HomeworkId  { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public DateTime ReleaseTime { get; set; }
        public bool Deleted { get; set; }
        public User User { get; set; }
        public Homework Homework { get; set; }
    }
}

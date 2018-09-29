using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Domain
{
     public class Homework
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public DateTime ReleaseTime { get; set; }
        public User User { get; set; }
    }
}

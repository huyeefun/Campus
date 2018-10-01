using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}

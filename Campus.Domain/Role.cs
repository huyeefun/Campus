using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { set; get; }
    }
}
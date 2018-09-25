using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.Dal
{
    public class CampusDbContext:DbContext
    {
        public CampusDbContext(DbContextOptions options) : base(options)
        {
        }
       
    }
}

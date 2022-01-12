using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.netCore.Models
{
    public class CDBcontexts:DbContext
    {
        public CDBcontexts(DbContextOptions<CDBcontexts> options) : base(options) {}
        public DbSet<TeacherModel> TeacherList { get; set; }
        public DbSet<CG> CGPATABLE { get; set; }
    }
}

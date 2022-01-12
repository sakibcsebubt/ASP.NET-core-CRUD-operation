using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.netCore.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string T_FName { get; set; }
        public string T_LName { get; set; }
        public string T_Designation { get; set; }
        public string T_Address { get; set; }
        public double T_Salery { get; set; }
        public string T_School { get; set; }
    }
    public class Viewmodel
    {
        public IEnumerable<TeacherModel> Teachers { get; set; }
        public IEnumerable<CG> CF { get; set; }
        public IEnumerable<VM> Test { get; set; }
    }
    public class VM
    {
        
        public string Sakib { get; set; }
        public string Ani { get; set; }
        

    }
    public class CG
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CGPA { get; set; }
    }
    
}

// Scaffold-DbContext "Server=SAKIB-PC\SQL2K12ENT;Database=Department;User ID=sa;Password=1234;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context CDBcontexts - Force
using CRUD.netCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.netCore.Controllers
{
    public class CGPAController : Controller
    {
        private readonly CDBcontexts _context;
        public CGPAController(CDBcontexts context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Viewmodel lst = new Viewmodel();
            var sda = _context.CGPATABLE.ToListAsync();
            return View();
        }
    }
}

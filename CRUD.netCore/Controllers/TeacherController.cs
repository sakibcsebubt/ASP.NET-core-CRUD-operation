using ClosedXML.Excel;
using CRUD.netCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.netCore.Controllers
{
    public class TeacherController : Controller
    {
        private readonly CDBcontexts _context;
        public TeacherController(CDBcontexts context)
        {
            _context = context;
        }
        // Scaffold-DbContext "Server=SAKIB-PC\SQL2K12ENT;Database=Department;User ID=sa;Password=1234;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context CDBcontexts - Force
        public async Task<IActionResult> index()
        {
            Viewmodel sa = new Viewmodel();

            var sda = await _context.TeacherList.ToListAsync();
            sa.Teachers = sda;

            return View(sa);
        }
        public async Task<IActionResult> ddata()
        {
            VM boss = new VM();
            var D = " Test ";
            var D1 = "Test2";
            boss.Sakib = D;
            boss.Ani = D1;

            return View(boss);
        }
        public IActionResult create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(TeacherModel teacher)
        {
            if (ModelState.IsValid)
            {
                _context.TeacherList.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Export));
            }
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var te = await _context.TeacherList.FirstOrDefaultAsync(e=>e.Id==id);
            if (te == null)
                return NotFound();

            return View(te);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherModel teacher)
        {
            if (!ModelState.IsValid)
                return View(teacher);
            var Data = "data ";
            _context.TeacherList.Update(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var te = await _context.TeacherList.FirstOrDefaultAsync(e => e.Id == id);
            if (te == null)
                return NotFound();

            _context.TeacherList.Remove(te);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
        public  FileResult Export()
        {


            DataTable dt = new DataTable("Practice1");
            dt.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Home"),
                new DataColumn("Position"),
                new DataColumn("Salery")
            });

            Viewmodel sa = new Viewmodel();

            var sda =  _context.TeacherList.ToList();
            //foreach(var teacher in sda)
            //{
            //    dt.Rows.Add(teacher.T_FName, teacher.T_Designation, teacher.T_Salery);
            //}

            int ind = 1;
            foreach (var item in sda)
            {
                dt.Rows.Add(item.Id,
                 item.T_FName,
                item.T_LName,
                item.T_Salery,
               item.T_Designation,
                item.T_Address,
                 item.T_School);

                //var range1 = wsheet1.Range["A" + ind.ToString() + ":H" + ind.ToString()];
                //range1.Font.Color = System.Drawing.Color.Black;
                //switch (item.txtcolor)
                //{
                //    case "Green":
                //        range1.Font.Color = System.Drawing.Color.Green;
                //        break;
                //    case "Red":
                //        range1.Font.Color = System.Drawing.Color.Red;
                //        break;
                //    case "Maroon":
                //        range1.Font.Color = System.Drawing.Color.Maroon;
                //        break;
                //    case "Blue":
                //        range1.Font.Color = System.Drawing.Color.Blue;
                //        break;
                //}
                //var formatRange = wsheet1.Range["D" + ind.ToString() + ":H" + ind.ToString()];
                //formatRange.NumberFormat = "#,###.00;(#,###.00); -";
                //range1.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                ind++;
            }


            using (XLWorkbook wb =new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using(MemoryStream stream=new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Grid.xlsx");
                }
            }

        }


    }
}

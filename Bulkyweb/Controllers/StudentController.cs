using Bulkyweb.Models;
using Microsoft.AspNetCore.Mvc;
using Bulkyweb.Data;
using Bulkyweb.Models;
using Bulkyweb.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace Bulkyweb.Controllers
{
    public class StudentController : Controller
    {
        public readonly ApplicationDBcontext dbcontext;
        public StudentController(ApplicationDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModal viewModal)
        {
            var student = new Student
            {
                Name = viewModal.Name,
                Email = viewModal.Email,
                Phone = viewModal.Phone,
                Subscribed = viewModal.Subscribed
            };
            await dbcontext.Students.AddAsync(student);

            await dbcontext.SaveChangesAsync();

            return View();

        }
        [HttpGet]

        public async Task<IActionResult> List()
        {
            var students = await dbcontext.Students.ToListAsync();
            return View(students);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbcontext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModal)
        {
          var student = await  dbcontext.Students.FindAsync(viewModal.Id);
            if(student is not null)
            {
                student.Name = viewModal.Name;
                student.Email = viewModal.Email;    
                student.Phone = viewModal.Phone;
                student.Subscribed = viewModal.Subscribed;
                await dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }

        [HttpPost]
        public async Task <IActionResult> Delete(Student viewModal)
        {
            var student = await dbcontext.Students.FirstOrDefaultAsync(x=>x.Id==viewModal.Id);
            if(student is not null)
            {
                 dbcontext.Students.Remove(viewModal);
                 await dbcontext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
    }
}
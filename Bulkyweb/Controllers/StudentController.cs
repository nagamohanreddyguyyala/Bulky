using Bulkyweb.Models;
using Microsoft.AspNetCore.Mvc;
using Bulkyweb.Data;
using Bulkyweb.Models;
using Bulkyweb.Models.Entities;
namespace Bulkyweb.Controllers
{
    public class StudentController : Controller
    {
        public readonly ApplicationDBcontext dbcontext;
        public StudentController(ApplicationDBcontext dBcontext) { 
        this.dbcontext = dBcontext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Add(AddStudentViewModal viewModal)
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

    }
}

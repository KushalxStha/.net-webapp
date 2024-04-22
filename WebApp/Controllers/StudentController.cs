using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var studentInfo= _context.Students.ToList();
            return View(studentInfo);
        }
        public IActionResult Add()
        {
            Student student = new Student();
            return View(student);
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var studentinfo = _context.Students.FirstOrDefault(x=> x.Id==id);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var studentinfo = _context.Students.FirstOrDefault(x => x.Id == student.Id);

            if (studentinfo != null)
            {
                studentinfo.FullName = student.FullName;
                studentinfo.PhoneNumber = student.PhoneNumber;
                studentinfo.Email = student.Email;
                studentinfo.Rollno = student.Rollno;

                _context.Update(studentinfo);
                _context.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }

        public IActionResult Remove(Student student)
        {

            var studentToDelete = _context.Students.FirstOrDefault(x => x.Id == student.Id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
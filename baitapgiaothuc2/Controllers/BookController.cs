using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class BookController : Controller
    {
        // Danh sách sách dữ liệu mẫu
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        // Chức năng 1: Danh sách sách
        // GET: /Book/Index hoặc /Book
        public IActionResult Index()
        {
            return View(books);
        }

        // Chức năng 2: Chi tiết sách
        // GET: /Book/Detail/1
        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return Content("Không tìm thấy sách!");
            }
            return View(book);
        }

        // Chức năng 3: Thêm sách (Hiển thị Form)
        // GET: /Book/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            // Kiểm tra xem dữ liệu gửi lên có vi phạm điều kiện trong Model hay không
            if (!ModelState.IsValid)
            {
                // Nếu vi phạm (Tên rỗng hoặc Giá <= 0), trả lại View kèm Model cũ để hiển thị lỗi
                return View(newBook);
            }

            // Nếu dữ liệu hợp lệ (ModelState.IsValid == true)
            int newId = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
            newBook.Id = newId;
            books.Add(newBook);

            ViewBag.Message = "Thêm sách thành công!";

            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login (Hiển thị trang đăng nhập)
        [HttpGet]
        [Route("Account")]
        [Route("Account/Login")]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login (Xử lý khi người dùng nhấn nút Login)
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Kiểm tra điều kiện theo đề bài bằng Model Binding (tự nhận tham số từ Form)
            if (username == "admin" && password == "123")
            {
                ViewBag.Message = "Login success";
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.Message = "Login failed";
                ViewBag.IsSuccess = false;
            }

            return View();
        }
    }
}
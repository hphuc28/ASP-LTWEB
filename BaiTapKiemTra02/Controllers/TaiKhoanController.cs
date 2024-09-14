using BaiTapKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra02.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                string result = $"Tên tài khoản: {model.Username}\n" +
                                $"Mật khẩu: {model.Password}\n" +
                                $"Họ tên: {model.HoTen}\n" +
                                $"Tuổi: {model.Tuoi}";
                return Content(result, "text/plain");
            }
            return View(model);
        }
    }



}

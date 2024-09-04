using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha02.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Do Hoang Phuc";
            ViewBag.MSSV = "1822030520";
            ViewBag.Nam = " 2024 ";
            return View();
        }
        public IActionResult MayTinh(int a, int b, string pheptinh)
        {
            double result = 0;
            string message = "";

            try
            {
                switch (pheptinh.ToLower())
                {
                    case "cộng":
                        result = a + b;
                        break;
                    case "trừ":
                        result = a - b;
                        break;
                    case "nhân":
                        result = a * b;
                        break;
                    case "chia":
                        if (b != 0)
                            result = (double)a / b;
                        else
                            message = "Không thể chia cho 0.";
                        break;
                    default:
                        message = "Phép tính không hợp lệ.";
                        break;
                }
            }
            catch (Exception ex)
            {
                message = $"Lỗi: {ex.Message}";
            }

            ViewBag.Result = result;
            ViewBag.Message = message;
            return View();
        }
    }
}

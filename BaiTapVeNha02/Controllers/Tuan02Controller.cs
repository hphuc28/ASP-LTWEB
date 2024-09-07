using Microsoft.AspNetCore.Mvc;
using System;

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
            double ketqua = 0;


            {
                switch (pheptinh)
                {
                    case "cộng":
                        ketqua = a + b;
                        break;
                    case "trừ":
                        ketqua = a - b;
                        break;
                    case "nhân":
                        ketqua = a * b;
                        break;
                    case "chia":
                        if (b != 0)
                            ketqua = (double)a / b;
                        else
                            ViewBag.Loi = "Không thể chia cho 0";
                        break;
                    default:
                        ViewBag.Loi = "Phép tính không hợp lệ";
                        break;
                }
            }
            if (ViewBag.Loi == null)
            {
                ViewBag.KetQua = ketqua;
            }

            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
    }
}

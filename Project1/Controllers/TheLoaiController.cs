﻿using Project1.Data;
using Project1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers
{
	[Area("Admin")]
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TheLoaiController(ApplicationDbContext db) 
        
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoai.ToList();
            ViewBag.TheLoai = theloai;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
		{
			
			return View();
		}
		[HttpPost]
		public IActionResult Create(TheLoai theLoai)
		{
            if (ModelState.IsValid)
            {
                //thêm thông tin
                _db.TheLoai.Add(theLoai);
                //Lưu 
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
			return View();
		}
		[HttpGet]
		public IActionResult Edit(int id)
        {
		    if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoai.Find(id);
			return View(theloai);
		}
		[HttpPost]
		public IActionResult Edit(TheLoai theLoai)
		{
			if (ModelState.IsValid)
			{
				//thêm thông tin
				_db.TheLoai.Update(theLoai);
				//Lưu 
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var theloai = _db.TheLoai.Find(id);
			return View(theloai);
		}
		[HttpPost]
		public IActionResult DeleteConfirm(int id)
		{
				var theloai = _db.TheLoai.Find(id);
				if(theloai == null)
				{
				return NotFound();
				}
				_db.TheLoai.Remove(theloai);
				_db.SaveChanges();
				return RedirectToAction("Index");
		}
		public IActionResult Detail(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var theloai = _db.TheLoai.Find(id);
			return View(theloai);
		}
		[HttpGet]
		public IActionResult Search(String searchString)
		{
			if (!String.IsNullOrEmpty(searchString))
			{
				//sử dụng Linq để tìm 
				var theloai = _db.TheLoai.
					Where(tl=>tl.Name.Contains(searchString)).ToList();

				ViewBag.SearchString = searchString;
				ViewBag.TheLoai = theloai;

			}
			else
			{ 
				var theloai =_db.TheLoai.ToList();
				ViewBag.TheLoai = theloai;
			}
			return View("Index"); //sử dụng lại view index
		}
	}
}

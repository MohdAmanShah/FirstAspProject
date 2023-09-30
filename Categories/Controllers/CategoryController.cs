using Categories.Data;
using Categories.Models;
using Microsoft.AspNetCore.Mvc;

namespace Categories.Controllers
{

	public class CategoryController : Controller
	{
		private readonly appdbcontext _db;
		public CategoryController(appdbcontext _context)
		{
			_db = _context;
		}
		public IActionResult Index()
		{
			IEnumerable<Category> categoryList = _db.CateGories;
			return View(categoryList);
		}
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(Category data)
		{
			if (ModelState.IsValid)
			{
				_db.CateGories.Add(data);
				_db.SaveChanges();
				TempData["success"] = "Data Added Successfully";
				return RedirectToAction("Index", "Category");
			}
			return View(data);
		}

		public IActionResult Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var data = _db.CateGories.Find(id);
			if (data == null)
			{
				return NotFound();
			}
			return View(data);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category data)
		{
			if (ModelState.IsValid)
			{
				_db.CateGories.Update(data);
				_db.SaveChanges();
				TempData["success"] = "Data Updated Successfully";
				return RedirectToAction("Index", "Category");
			}
			return View(data);
		}

		public IActionResult Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var data = _db.CateGories.Find(id);
			if (data == null)
			{
				return NotFound();
			}
			return View(data);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Category data)
		{
			_db.CateGories.Remove(data);
			_db.SaveChanges();
			TempData["success"] = "Data Deleted Successfully";
			return RedirectToAction("Index", "Category");
		}

	}
}
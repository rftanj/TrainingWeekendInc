using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCMSTraining.Context;
using WebCMSTraining.Helper;
using WebCMSTraining.Models.DB;
using WebCMSTraining.Models.DTO;

namespace WebCMSTraining.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class CategoryController : Controller
    {
        public readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        //[SessionHelper]
        public IActionResult Index()
        {

            return View();

            //try
            //{
            //    var getResultCategory = _context.Categories.Where(x => x.Status != Category.CategoryStatus.Trash).ToList();
            //    return View(getResultCategory);
            //}
            //catch (Exception ex)
            //{

            //    return NotFound( new { Message = ex.Message });
            //}
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoadDataCategory()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var categoryDataa = _context.Categories.Where(x => x.Status != Category.CategoryStatus.Trash).ToList();

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    categoryDataa = categoryDataa.OrderBy(sort => sortColumn + " " + sortColumnDirection).ToList();
                   
                }
               
                if (!string.IsNullOrEmpty(searchValue))
                {
                    categoryDataa = _context.Categories.Where(x => x.CategoryName == searchValue).ToList();
                }

                recordsTotal = categoryDataa.Count();
                var data = categoryDataa.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory([Bind("CategoryName, CategoryStatus")] CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                Category categoryData = new Category()
                {
                    Status = (Category.CategoryStatus)Enum.Parse(typeof(Category.CategoryStatus), categoryDTO.CategoryStatus.ToString())
                };

                var category = new Category
                {
                    CategoryName = categoryDTO.CategoryName,
                    Status = categoryData.Status
                };

                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult UpdateCategory(int Id)
        {
            var GetCategory = _context.Categories.Find(Id);
            return View(GetCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory([Bind("Id, CategoryName, Status")] Category category)
        {
            var findCategory = _context.Categories.Find(category.Id);

            Category categoryData = new Category()
            {
                Status = (Category.CategoryStatus)Enum.Parse(typeof(Category.CategoryStatus), category.Status.ToString())
            };

            if (ModelState.IsValid)
            {
                findCategory.CategoryName = category.CategoryName;
                findCategory.Status = categoryData.Status;

                _context.Update(findCategory);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult DeleteCategory(int Id)
        {
            var GetCategory = _context.Categories.FirstOrDefault(x => x.Id == Id);
            if (GetCategory == null)
            {
                return NotFound();
            }

            GetCategory.Status = Category.CategoryStatus.Trash;
            _context.Update(GetCategory);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}

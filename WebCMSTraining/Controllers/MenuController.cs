using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebCMSTraining.Context;
using WebCMSTraining.Models.DB;
using WebCMSTraining.Models.DTO;

namespace WebCMSTraining.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MenuController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var GetCatMenu = (from M in _context.Menus
                              join C in _context.Categories on M.CategoryId equals C.Id
                              where M.Status != Menu.MenuStatus.Trash
                              select new Menu
                              {
                                  CategoryName = C.CategoryName,
                                  Id = M.Id,
                                  Picture = M.Picture,
                                  MenuName = M.MenuName,
                                  Price = M.Price,
                                  Stock = M.Stock,
                                  Status = M.Status
                              }).ToList();

            return View(GetCatMenu);
        }

        public IActionResult CreateMenu()
        {
            var cek = new MenuDTO();

            cek.CategoryName = _context.Categories
                .Where(x => x.Status == Category.CategoryStatus.Published)
                .Select(x => new SelectListItem 
                {
                    Value = x.Id.ToString(),
                    Text = x.CategoryName
                });

            return View(cek);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMenu([Bind("CategoryId, MenuName, Price, Stock, Status")] MenuDTO menuDTO, IFormFile Picture)
        {
            if (ModelState.IsValid)
            {
                Menu MenuData = new Menu()
                {
                    Status = (Menu.MenuStatus)Enum.Parse(typeof(Menu.MenuStatus), menuDTO.Status.ToString())
                };

                if (Picture != null)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + Picture.FileName;
                    string filePath = Path.Combine(_env.WebRootPath, "uploads/img");
                    string fullPath = Path.Combine(filePath, fileName);

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await Picture.CopyToAsync(stream);
                    }

                    menuDTO.Picture = fileName;
                }


                var menu = new Menu
                {
                    CategoryId = menuDTO.CategoryId,
                    Picture = menuDTO.Picture,
                    MenuName = menuDTO.MenuName,
                    Price = menuDTO.Price,
                    Stock = menuDTO.Stock,
                    Status = MenuData.Status
                };

                _context.Menus.Add(menu);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult UpdateMenu(int Id)
        {
            var getMenu = _context.Menus
                .Where(x => x.Id == Id)
                .Select(x => new MenuDTO()
            {
                CategoryId = x.CategoryId,
                MenuName = x.MenuName,
                Picture = x.Picture,
                Price = x.Price,
                Stock = x.Stock
            }).FirstOrDefault();


            getMenu.CategoryName = _context.Categories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CategoryName,
                Selected = getMenu.CategoryId == x.Id
            });

            return View(getMenu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMenu([Bind("Id, CategoryId, MenuName, Price, Stock, Status")] MenuDTO menuDTO, IFormFile Picture)
        {
            if (ModelState.IsValid)
            {
                var findMenu = _context.Menus.Find(menuDTO.Id);

                if (Picture != null)
                {
                    string fileName = Guid.NewGuid().ToString()+"-"+Picture.FileName;
                    string filePath = Path.Combine(_env.WebRootPath, "uploads/img");
                    string fullPath = Path.Combine(filePath, fileName);
                    if (!Directory.Exists(filePath))
                    { 
                        Directory.CreateDirectory(filePath);
                    }

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await Picture.CopyToAsync(stream);
                    }

                    findMenu.Picture = fileName;
                }

                findMenu.CategoryId = menuDTO.CategoryId;
                findMenu.MenuName = menuDTO.MenuName;
                findMenu.Price = menuDTO.Price;
                findMenu.Stock = menuDTO.Stock;
                findMenu.Status = (Menu.MenuStatus)Enum.Parse(typeof(Menu.MenuStatus), menuDTO.Status.ToString());


                _context.Update(findMenu);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]

        public IActionResult DeleteMenu(int Id)
        {
            var GetMenu = _context.Menus.FirstOrDefault(x => x.Id == Id);
            if (GetMenu == null)
            {
                return NotFound();
            }
            GetMenu.Status = Menu.MenuStatus.Trash;
            _context.Update(GetMenu);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

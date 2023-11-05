using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCMSTraining.Context;
using WebCMSTraining.Models.DB;
using WebCMSTraining.Models.DTO;

namespace WebCMSTraining.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class DiscountController : Controller
    {
        public readonly AppDbContext _context;

        public DiscountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var GetDiscount = _context.Discounts.Where(x => x.Status != Discount.DiscountStatus.Trash).ToList();
            return View(GetDiscount);
        }

        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDiscount([Bind("DiscountCode, DiscountName, DiscountType, DiscountValue, StartPeriod, EndPeriod, Status")] DiscountDTO discountDTO)
        {
            bool check = false;

            if (ModelState.IsValid)
            {
                Discount discountData = new Discount()
                {
                    Status = (Discount.DiscountStatus)Enum.Parse(typeof(Discount.DiscountStatus), discountDTO.Status.ToString())
                };

                if (discountDTO.DiscountType == "Persen" && (discountDTO.DiscountValue > 100 || discountDTO.DiscountValue < 0))
                {
                    ModelState.AddModelError("DiscountValue", "Persen Invalid");

                    check = false;
                }
                else
                {
                    check = true;
                }

                if (discountDTO.StartPeriod >= discountDTO.EndPeriod)
                {
                    ModelState.AddModelError("StartPeriod", "Date Invalid");
                    ModelState.AddModelError("EndPeriod", "Date Invalid");

                    check = false;
                }
                else
                {
                    check = !check ? false : true;
                }

                if (check)
                {
                    var GetDiscount = new Discount
                    {
                        DiscountCode = discountDTO.DiscountCode,
                        DiscountName = discountDTO.DiscountName,
                        DiscountType = discountDTO.DiscountType,
                        DiscountValue = discountDTO.DiscountValue,
                        StartPeriod = discountDTO.StartPeriod,
                        EndPeriod = discountDTO.EndPeriod,
                        Status = discountData.Status
                    };

                    _context.Add(GetDiscount);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult UpdateDiscount(int Id)
        {
            var GetDiscount = _context.Discounts.Find(Id);
            return View(GetDiscount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDiscount(int Id)
        {
            var GetDiscount = _context.Discounts.FirstOrDefault(x => x.Id == Id);
            if(GetDiscount == null)
            {
                return NotFound();
            }
            GetDiscount.Status = Discount.DiscountStatus.Trash;
            _context.Update(GetDiscount);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

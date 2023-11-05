using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCMSTraining.Context;
using WebCMSTraining.Models.DB;
using WebCMSTraining.Models.DTO;

namespace WebCMSTraining.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public OrderController(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var getOrder = _context.Orders.Where(x => x.Status != Order.StatusData.Trash).ToList();
            return View(getOrder);
        }

        public IActionResult ExportOrder()
        {
            var getOrder = _context.Orders.Where(x => x.Status != Order.StatusData.Trash).ToList();
            var Builder = new StringBuilder();
            Builder.AppendLine("Transaction Id, Username, Discount Id, Discount Code, Transaction Date, Order Status, Total Price, Total, Status, Driver");
            foreach (var order in getOrder)
            {
                Builder.AppendLine($"{order.Id}, {order.UserName}, " +
                    $"{order.DiscountId}, {order.DiscountCode}, {order.TransactionDate}," +
                    $"{order.OrderStatus},{order.TotalPrice}, {order.Total}, {order.Driver}");

            }

            return File(Encoding.UTF8.GetBytes(Builder.ToString()), "text/csv","Order.csv");
        }

        public IActionResult ExportDetailOrder()
        {
            var getOrder = _context.DetailOrders.Where(x => x.Status != Models.DB.DetailOrder.StatusData.Trash).ToList();
            var Builder = new StringBuilder();
            Builder.AppendLine("ID, Order ID, Menu ID, Menu Name, Price, Quantity");
            foreach (var detailorder in getOrder)
            {
                Builder.AppendLine($"{detailorder.Id}, {detailorder.OrderId}, " +
                    $"{detailorder.MenuId}, {detailorder.MenuName}, " +
                    $"{detailorder.Price},{detailorder.Quantity}");

            }

            return File(Encoding.UTF8.GetBytes(Builder.ToString()), "text/csv", "Order Detail.csv");
        }

        public async Task<IActionResult> DetailOrder(int Id)
        {

            var getRoles = await _roleManager.FindByNameAsync("Driver");
            var getDriver = await _userManager.GetUsersInRoleAsync(getRoles.Name);

            var detailOrder = _context.DetailOrders.Where(x => x.OrderId == Id).ToList();
            var Order = _context.Orders.Find(Id);

            //DetailOrderDTO untuk menampung Order & Detail Order Untuk
            //Ditampilin ke View {2 Tabel Kedalam 1 View (List dan Data)}

            DetailOrderDTO detailOrderDTO = new DetailOrderDTO              
            {
                detailOrder = detailOrder,
                order = Order
            };

            //Untuk nampilin data kedalam DropDownList pakai ViewBag
            var TryGet = getDriver          
                .Where(x => x.Status == Models.DB.User.UserStatus.Published)
                .Select(x => new SelectListItem
                {
                    Value = x.Name,
                    Text = x.Name
                });

            ViewBag.SelectListDriver = TryGet;

            return View(detailOrderDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetDriver([Bind("Driver, Id")] Order order)
        {
            var getOrd = _context.Orders.Find(order.Id);
            if (getOrd is null)
            {
                return null; 
            }

            getOrd.Driver = order.Driver;
            getOrd.OrderStatus = Order.OrderCheck.Delivered;

            _context.Update(getOrd);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

       

    }
}

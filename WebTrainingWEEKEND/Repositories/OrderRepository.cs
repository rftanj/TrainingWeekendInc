using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTrainingWEEKEND.Context;
using WebTrainingWEEKEND.Models.DB;
using WebTrainingWEEKEND.Models.DTO;
using Microsoft.AspNetCore.Identity;
using WebTrainingWEEKEND.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTrainingWEEKEND.Repositories
{
    public class OrderRepository : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        //Httpcontext berlaku ketika ingin mengambil Data User yang sedang Login
        //Dan harus di setting di Starup.cs -> Services
        private readonly HttpContext _httpContext;
        public OrderRepository(AppDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContext)
        {
            _context = context;
            _userManager = userManager;
            _httpContext = httpContext.HttpContext;

        }

        //public async Task<IEnumerable<Order>> GetOrders()
        //{
        //    return await _context.Orders
        //       .Where(x => x.Status != Order.StatusData.Deleted)
        //       .ToListAsync();
        //}

        //public async Task<IEnumerable<Order>> GetOrderByDriver()
        //{
        //    return await _context.Orders
        //       .Where(x => x.OrderStatus == Order.OrderCheck.Process)
        //       .ToListAsync();
        //}

        public async Task<CheckResponse> TakeOrder(TakeOrderDTO takeOrderDTO)
        {
            try
            {
                //=== Periksa data order ada atau tidak ===//
                var TakeOr = _context.Orders.FirstOrDefault(x => x.Id == takeOrderDTO.Id);
                if (TakeOr != null)
                {
                    TakeOr.OrderStatus = Order.OrderCheck.Delivered;

                    _context.Update(TakeOr);
                    await _context.SaveChangesAsync();

                    return new CheckResponse
                    {
                        isError = false
                    };
                }
                else
                {
                    throw new Exception("Order is Not Found!");
                }
            }
            catch (Exception ex)
            {
                return new CheckResponse
                {
                    isError = true,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<CheckResponse> AddToCart(AddtoCartDTO addTocart)
        {
            try
            {
                //var UserName = _httpContext.User.Identity.Name;
                //var dataUser = await _userManager.FindByNameAsync(UserName);
                //var alamat = dataUser.PhoneNumber;

                //=== NOTE ====\\
                //Pertama kita gunakan 'var UserName' untuk mendapatkan Identity User yang sedang Login
                //Lalu apabila didapatkan data User yang telah sedang Login, kemudia combine dengan UserManager "Contoh dibaris 'var dataUser'"
                //Kemudian 'dataUser' akan bertipe 'Class' yang dimana kita akses property apapun yang ada didalam 'Class' tersebut.
                //Untuk contoh ada dibagian 'var Alamat'


                var getMenu = _context.Menus.FirstOrDefault(x => x.Id == addTocart.MenuId); //=== Mencek menu tersedia atau tidak ===//
                if (getMenu != null) 
                {
                    if (getMenu.Stock >= addTocart.Quantity && addTocart.Quantity > 0)
                    {
                        //=== Insert kedalam tabel order ===//
                      
                        var newOrder = new Order
                        {
                            UserName = _httpContext.User.Identity.Name,     //Get Name berdasarkan User yang login
                            TransactionDate = DateTime.Now,
                            OrderStatus = Order.OrderCheck.Pending,
                            Status = Order.StatusData.Published
                        };

                        _context.Orders.Add(newOrder);
                        await _context.SaveChangesAsync();

                        //=== Insert kedalam tabel detailorder ===//
                        var newDetailOrder = new DetailOrder
                        {
                            OrderId = newOrder.Id,
                            MenuId = addTocart.MenuId,
                            MenuName = getMenu.MenuName,
                            Price = getMenu.Price,
                            Quantity = addTocart.Quantity,
                            Status = DetailOrder.StatusData.Published
                        };

                        _context.DetailOrders.Add(newDetailOrder);
                        await _context.SaveChangesAsync();

                        return new CheckResponse
                        {
                            isError = false
                        };
                    }
                    else
                    {
                        throw new Exception("Quantity is Overbooking Or Invalid!");
                    }
                }
                else
                {
                    throw new Exception("Menu is Not Found, Please Choose Again");
                }
            }
            catch (Exception ex)
            {
                return new CheckResponse
                {
                    isError = true,
                    ErrorMessage = ex.Message
                };
            }
        }

        //public async Task<bool> CheckOut(CheckoutDTO checkout)
        //{
        //    try
        //    {
        //        //=== Mencek apakah DiscoundCode tersedia atau tidak dan mencek Status Discount harus publish ===//
        //        var getDataDiscount = _context.Discounts.AsNoTracking()
        //            .FirstOrDefault(x => x.DiscountCode == checkout.DiscountCode && x.Status != Discount.DiscountStatus.Deleted);

        //        //var getDataOrder = _context.Orders.AsNoTracking().Where(p => p.OrderStatus == Order.OrderCheck.Pending);

        //        //==== Get data yang mau di update ketika checkout  ====//
        //        var get = (from dO in _context.DetailOrders.AsNoTracking()
        //                   join Orr in _context.Orders.AsNoTracking() on dO.OrderId equals Orr.Id
        //                   join Mn in _context.Menus.AsNoTracking() on dO.MenuId equals Mn.Id 
        //                   where Orr.OrderStatus == Order.OrderCheck.Pending
        //                   select new
        //                   {
        //                       OrrDetail = dO,
        //                       MainOrd = Orr,
        //                       MenuStock = Mn
        //                   });

        //        //var getIdOrder = getDataOrder.Select(x => x.Id);
        //        //var getDetailOrder = _context.DetailOrders.first(s => getIdOrder.Contains(s.OrderId));

        //        foreach (var Item in get)
        //        {
        //            // === Mencek apakah DiscountCode ada atau tidak === //
        //            if(checkout.DiscountCode < 1)
        //            {
        //                Item.MainOrd.OrderStatus = Order.OrderCheck.Process;
        //                Item.MainOrd.TotalPrice = Item.OrrDetail.Price * Item.OrrDetail.Quantity;
        //                Item.MainOrd.Total = Item.MainOrd.TotalPrice;
        //                Item.MenuStock.Stock = Item.MenuStock.Stock - Item.OrrDetail.Quantity;

        //                _context.Update(Item.MainOrd);
        //            }
        //            else
        //            {
        //                //=== Mencek masa expired discount ===//
        //                if (DateTime.Now >= getDataDiscount.StartPeriod && DateTime.Now <= getDataDiscount.EndPeriod)
        //                {
        //                    Item.MainOrd.DiscountId = getDataDiscount.Id;
        //                    Item.MainOrd.DiscountCode = getDataDiscount.DiscountCode;
        //                    Item.MainOrd.OrderStatus = Order.OrderCheck.Process;
        //                    Item.MainOrd.TotalPrice = Item.OrrDetail.Price * Item.OrrDetail.Quantity;
        //                    Item.MainOrd.Total = getDataDiscount.DiscountType == "Nominal" ?
        //                                (Item.MainOrd.TotalPrice - getDataDiscount.DiscountValue) < 1 ? 0 : Item.MainOrd.TotalPrice - getDataDiscount.DiscountValue :
        //                                (Item.MainOrd.TotalPrice - (Item.MainOrd.TotalPrice * getDataDiscount.DiscountValue / 100));
        //                    Item.MenuStock.Stock = Item.MenuStock.Stock - Item.OrrDetail.Quantity;

        //                    _context.Update(Item.MainOrd);
        //                }
        //            }

        //        }
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //}

        public async Task<CheckResponse> CheckOut(CheckoutDTO checkout)
        {
            try
            {
                //=== Mencek apakah DiscoundCode tersedia atau tidak dan mencek Status Discount harus publish ===//
                var getDataDiscount = _context.Discounts.AsNoTracking()
                    .FirstOrDefault(x => x.DiscountCode == checkout.DiscountCode && x.Status != Discount.DiscountStatus.Deleted);

                //var getDataOrder = _context.Orders.AsNoTracking().Where(p => p.OrderStatus == Order.OrderCheck.Pending);

                //==== Get data yang mau di update ketika checkout  ====//
                var get = (from dO in _context.DetailOrders.AsNoTracking()
                           join Orr in _context.Orders.AsNoTracking() on dO.OrderId equals Orr.Id
                           join Mn in _context.Menus.AsNoTracking() on dO.MenuId equals Mn.Id
                           where Orr.OrderStatus == Order.OrderCheck.Pending
                           select new
                           {
                               OrrDetail = dO,
                               MainOrd = Orr,
                               MenuStock = Mn
                           });

                //var getIdOrder = getDataOrder.Select(x => x.Id);
                //var getDetailOrder = _context.DetailOrders.first(s => getIdOrder.Contains(s.OrderId));

                foreach (var Item in get)
                {
                    // === Mencek apakah DiscountCode ada atau tidak === //
                    if (checkout.DiscountCode < 1)
                    {
                        Item.MainOrd.OrderStatus = Order.OrderCheck.Process;
                        Item.MainOrd.TotalPrice = Item.OrrDetail.Price * Item.OrrDetail.Quantity;
                        Item.MainOrd.Total = Item.MainOrd.TotalPrice;
                        Item.MenuStock.Stock = Item.MenuStock.Stock - Item.OrrDetail.Quantity;

                        _context.Update(Item.MainOrd);
                        _context.Update(Item.MenuStock);
                    }
                    else
                    {
                        //=== Mencek masa expired discount ===//
                        if (DateTime.Now >= getDataDiscount.StartPeriod && DateTime.Now <= getDataDiscount.EndPeriod)
                        {
                            Item.MainOrd.DiscountId = getDataDiscount.Id;
                            Item.MainOrd.DiscountCode = getDataDiscount.DiscountCode;
                            Item.MainOrd.OrderStatus = Order.OrderCheck.Process;
                            Item.MainOrd.TotalPrice = Item.OrrDetail.Price * Item.OrrDetail.Quantity;
                            Item.MainOrd.Total = getDataDiscount.DiscountType == "Nominal" ?
                                        (Item.MainOrd.TotalPrice - getDataDiscount.DiscountValue) < 1 ? 0 : Item.MainOrd.TotalPrice - getDataDiscount.DiscountValue :
                                        (Item.MainOrd.TotalPrice - (Item.MainOrd.TotalPrice * getDataDiscount.DiscountValue / 100));
                            Item.MenuStock.Stock = Item.MenuStock.Stock - Item.OrrDetail.Quantity;

                            _context.Update(Item.MainOrd);
                            _context.Update(Item.MenuStock);
                        }
                        else
                        {
                            throw new Exception("Discount Has Expired!");
                        }
                    }

                }
                await _context.SaveChangesAsync();

                return new CheckResponse
                {
                    isError = false
                };
            }
            catch (Exception ex)
            {
                return new CheckResponse
                {
                    isError = true,
                    ErrorMessage = ex.Message
                };
            }
        }

        //public async Task<IEnumerable<Order>> GetOrderByUserName(string Username)
        //{
        //    //=== Untuk mendapatkan data menggunakan syntax "Like" di SQL ===//
        //    return await _context.Orders.
        //        Where(x => x.UserName.ToLower().Contains(Username.ToLower())).ToListAsync();
        //}
         

    }
}

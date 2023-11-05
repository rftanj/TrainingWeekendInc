using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTrainingWEEKEND.Helper;
using WebTrainingWEEKEND.Models.DB;
using WebTrainingWEEKEND.Models.DTO;
using WebTrainingWEEKEND.Repositories;

namespace WebTrainingWEEKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;


        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        //[HttpGet]
        //[Route("get-order")]
        //[Authorize(Roles = UserRoles.Admin)]
        //public async Task<IEnumerable<Order>> GetOrders()
        //{
        //    return await _orderRepository.GetOrders();
        //}

        //[HttpGet("{UserName}")]
        //[Authorize(Roles = UserRoles.User)]
        //public async Task<IEnumerable<Order>> GetOrdersByUserName(string UserName)
        //{
        //    return await _orderRepository.GetOrderByUserName(UserName);
        //}

        [HttpPost]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> AddOrder([FromBody] AddtoCartDTO addtoCart)
        {

            var getUserNameAuth = User.FindFirstValue(ClaimTypes.Name);

            var action = await _orderRepository.AddToCart(addtoCart);
                
            if (action.isError)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDTO() { Status = "Failed", Message = action.ErrorMessage});
            }

            return Ok(new ResponseDTO() { Status = "Success", Message = "Order Added Successfully" });
                
           
        }

        [HttpPost]
        [Route("checkout")]
        [Authorize(Roles = UserRoles.User)]

        public async Task<IActionResult> CheckOut([FromBody] CheckoutDTO checkout)
        {
            var action = await _orderRepository.CheckOut(checkout);
            
            if(action.isError){
                return StatusCode(StatusCodes.Status400BadRequest,
                new ResponseDTO() { Status = "Failed", Message = action.ErrorMessage });
            }
            return Ok(new ResponseDTO() { Status = "Success", Message = "Checkout Succesfully!" });
        }

        //public async Task<IActionResult> CheckOut([FromBody] CheckoutDTO checkout )
        //{
        //    if (await _orderRepository.CheckOut(checkout))
        //    {
        //        return Ok(new ResponseDTO() { Status = "Success", Message = "Checkout Succesfully!" });
        //    }

        //    return StatusCode(StatusCodes.Status400BadRequest,
        //        new ResponseDTO() { Status = "Failed", Message = "Please Check Your Booking Code" });
        //}


        //[HttpGet]
        //[Route("get-order-driver")]
        //[Authorize(Roles = UserRoles.Driver)]
        //public async Task<IEnumerable<Order>> GetOrdersbyDriver()
        //{
        //    return await _orderRepository.GetOrderByDriver();
        //}

        [HttpPost]
        [Route("take-order")]
        [Authorize(Roles = UserRoles.Driver)]
        public async Task<IActionResult> TakeOrder([FromBody] TakeOrderDTO takeOrderDTO)
        {
            var action = await _orderRepository.TakeOrder(takeOrderDTO);

            if (action.isError) 
            {
                return StatusCode(StatusCodes.Status404NotFound,
                   new ResponseDTO() { Status = "Failed", Message = action.ErrorMessage });
            }
            
            return Ok(new ResponseDTO() { Status = "Success", Message = "Order Delivered!" });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTrainingWEEKEND.Helper;
using WebTrainingWEEKEND.Helper.Pagination;
using WebTrainingWEEKEND.Models.DB;
using WebTrainingWEEKEND.Models.DTO;
using WebTrainingWEEKEND.Repositories;

namespace WebTrainingWEEKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountRepository _discountRepository;

        public DiscountController(DiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<DiscountDTO>> GetDiscount([FromQuery] Paging paging)
        {
            return await _discountRepository.GetAllDiscount(paging);
        }
    }
}

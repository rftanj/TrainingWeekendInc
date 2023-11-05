using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTrainingWEEKEND.Repositories;
using WebTrainingWEEKEND.Models.DB;
using WebTrainingWEEKEND.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using WebTrainingWEEKEND.Helper;
using WebTrainingWEEKEND.Helper.Pagination;

namespace WebTrainingWEEKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuRepository _menuRepository;

        public MenuController(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.User)]
        public async Task<ActionResult<IEnumerable<MenuDTO>>> GetMenu([FromQuery] Paging pagination)
        {
            return await _menuRepository.GetAllMenu(pagination);
        }
        
        
    }
}

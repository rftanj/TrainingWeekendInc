using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTrainingWEEKEND.Context;
using WebTrainingWEEKEND.Repositories;
using WebTrainingWEEKEND.Models.DB;
using WebTrainingWEEKEND.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using WebTrainingWEEKEND.Helper;

namespace WebTrainingWEEKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategory()
        {
            return await _categoryRepository.GetCategory();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTrainingWEEKEND.Models.DB;
using WebTrainingWEEKEND.Context;
using Microsoft.AspNetCore.Mvc;
using WebTrainingWEEKEND.Models.DTO;
using System.Web.Mvc;

namespace WebTrainingWEEKEND.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategory()
        {
            return await _context.Categories
                .Where(x => x.Status != Category.CategoryStatus.Deleted)
                .Select(x => new CategoryDTO() { 
                    Id = x.Id,
                    CategoryName = x.CategoryName
                }).ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTrainingWEEKEND.Context;
using WebTrainingWEEKEND.Models.DB;
using Microsoft.EntityFrameworkCore;
using WebTrainingWEEKEND.Models.DTO;
using WebTrainingWEEKEND.Helper.Pagination;
using WebTrainingWEEKEND.Repositories;

namespace WebTrainingWEEKEND.Repositories
{
    public class MenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<MenuDTO>> GetAllMenu(Paging page)
        {
            var GMenu = await GetMenu();
            return await Task.FromResult(PagedList<MenuDTO>.GetPagesList(GMenu.AsQueryable().OrderBy(x => x.Id), page.pageNumber, page.PageSize ));
        }

        public async Task<IEnumerable<MenuDTO>> GetMenu()
        {
            
            return await _context.Menus
                .Where(x => x.Status != Menu.MenuStatus.Deleted)
                .Select(x => new MenuDTO() { 
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    MenuName = x.MenuName,
                    Price = $"Rp. {x.Price}",
                    Stock = x.Stock
                }).ToListAsync();
        }
    }
}

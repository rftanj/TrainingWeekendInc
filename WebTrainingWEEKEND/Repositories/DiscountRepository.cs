using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTrainingWEEKEND.Context;
using WebTrainingWEEKEND.Models.DB;
using Microsoft.EntityFrameworkCore;
using WebTrainingWEEKEND.Models.DTO;
using WebTrainingWEEKEND.Repositories;
using WebTrainingWEEKEND.Helper.Pagination;

namespace WebTrainingWEEKEND.Repositories
{
    public class DiscountRepository
    {
        private readonly AppDbContext _context;

        public DiscountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<DiscountDTO>> GetAllDiscount(Paging page)
        {
            var GetDisc = await GetDiscount();
            return await Task.FromResult(PagedList<DiscountDTO>.GetPagesList(GetDisc.AsQueryable().OrderBy(x => x.Id), page.pageNumber, page.PageSize));
        }

        public async Task<IEnumerable<DiscountDTO>> GetDiscount()
        {
            var getAllDisc = await _context.Discounts
                .Where(x => x.Status != Discount.DiscountStatus.Deleted)
                .Select(x => new DiscountDTO() { 
                    Id = x.Id,
                    DiscountCode = x.DiscountCode,
                    DiscountName = x.DiscountName,
                    DiscountType = x.DiscountType,
                    DiscountValue = x.DiscountValue,
                    StartPeriod = x.StartPeriod.ToString("yyyy-MM-dd"),
                    EndPeriod = x.StartPeriod.ToString("yyyy-MM-yy")
                }).ToListAsync();

            return getAllDisc;
        }
    }
}

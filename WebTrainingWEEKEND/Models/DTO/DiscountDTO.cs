using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Models.DTO
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public int DiscountCode { get; set; }
        public string DiscountName { get; set; }
        public string DiscountType { get; set; }
        public int DiscountValue { get; set; }
        public string StartPeriod { get; set; }
        public string EndPeriod { get; set; }

    }
}

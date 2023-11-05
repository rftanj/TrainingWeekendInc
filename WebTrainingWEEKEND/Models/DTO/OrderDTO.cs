using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string UserName { get; set; }
        public int DiscountId { get; set; }
        public int DiscountCode { get; set; }

        [Required(ErrorMessage = "Required!")]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Required!")]
        public int OrderQty { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Required!")]
        public string MenuName { get; set; }
        [Required(ErrorMessage = "Required!")]
        public int Price { get; set; }
    }
}

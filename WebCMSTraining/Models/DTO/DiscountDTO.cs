using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DTO
{
    public class DiscountDTO
    {
        [Required(ErrorMessage = "Discount Code is Required")]
        public int DiscountCode { get; set; }

        [Required(ErrorMessage = "Discount Name is Required")]
        public string DiscountName { get; set; }

        [Required(ErrorMessage = "Discount Type is Required")]
        public string DiscountType { get; set; }

        [Required(ErrorMessage = "Discount Value is Required")]
        [Range(0,Int32.MaxValue)]
        public int DiscountValue { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }

        [Column(TypeName = "enum('Published','Unpublished')")]
        public DiscountStat Status { get; set; }
        public enum DiscountStat
        {
            Published,
            Unpublished
        }
    }
}

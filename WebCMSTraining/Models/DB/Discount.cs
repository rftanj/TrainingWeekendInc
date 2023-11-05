using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DB
{
    public class Discount
    {
        public int Id { get; set; }
        public int DiscountCode { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string DiscountName { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string DiscountType { get; set; }
        public int DiscountValue { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }

        [Column(TypeName = "enum('Unpublished', 'Published', 'Trash')")]
        public DiscountStatus Status { get; set; }
        public enum DiscountStatus
        {
            Published,
            Unpublished,
            Trash
        }
    }
}

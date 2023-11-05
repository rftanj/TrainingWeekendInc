using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Models.DB
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName {get; set;}
        public int DiscountId { get; set; }
        public int DiscountCode { get; set; }
        public DateTime TransactionDate { get; set; }

        [Column(TypeName =("enum('Pending','Process','Delivered')"))]
        public OrderCheck OrderStatus { get; set; }
        public int TotalPrice { get; set; }
        public int Total { get; set; }

        [Column(TypeName = ("enum('Deleted','Published')"))]
        public StatusData Status { get; set; }
        public enum OrderCheck {
            Pending,
            Process,
            Delivered
        }
        public enum StatusData {
            Published,
            Deleted,
            Trash
        }

    }
}

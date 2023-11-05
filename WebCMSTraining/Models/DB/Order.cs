using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCMSTraining.Models.DB
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int DiscountId { get; set; }
        public int DiscountCode { get; set; }
        public DateTime TransactionDate { get; set; }

        [Column(TypeName = ("enum('Pending','Process','Delivered')"))]
        public OrderCheck OrderStatus { get; set; }
        public int TotalPrice { get; set; }
        public int Total { get; set; }
        public string Driver { get; set; }

        [Column(TypeName = ("enum('Published','Unpublished','Trash')"))]
        public StatusData Status { get; set; }
        public enum OrderCheck
        {
            Pending,
            Process,
            Delivered
        }
        public enum StatusData
        {
            Published,
            Unpublished,
            Trash
        }

        [NotMapped]
        public IEnumerable<SelectListItem> DriverName
        {
            get; set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebCMSTraining.Models.DB;

namespace WebCMSTraining.Models.DTO
{
    public class DetailOrderDTO
    {

        public List<DetailOrder> detailOrder { get; set; }
        public Order order { get; set; }


        //public int Id { get; set; }
        //public string UserName { get; set; }
        //public int DiscountId { get; set; }
        //public int DiscountCode { get; set; }
        //public DateTime TransactionDate { get; set; }
        //public int TotalPrice { get; set; }
        //public int Total { get; set; }
        //public string Driver { get; set; }
        //public string MenuName { get; set; }
        //public int Price { get; set; }
        //public int Quantity { get; set; }

        //[Column(TypeName = ("enum('Pending','Process','Delivered')"))]
        //public StatusOrder OrderStatus { get; set; }
        //public enum StatusOrder
        //{
        //    Pending,
        //    Process,
        //    Delivered
        //}
    }
}

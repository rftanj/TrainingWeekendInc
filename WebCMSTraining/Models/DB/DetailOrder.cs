using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DB
{
    public class DetailOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = ("enum('Published','Unpublished','Trash')"))]
        public StatusData Status { get; set; }
        public enum StatusData
        {
            Published,
            Unpublished,
            Trash
        }
    }
}

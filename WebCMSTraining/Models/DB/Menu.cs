using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DB
{
    public class Menu
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string MenuName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

        [Column(TypeName = "enum('Published','Unpublished','Trash')")]
        public MenuStatus Status { get; set; }
        public enum MenuStatus
        {
            Published,
            Unpublished,
            Trash
        }
    }
}

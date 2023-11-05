using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Models.DTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string MenuName { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Models.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}

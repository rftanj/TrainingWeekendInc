using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DTO
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "Category Name is Required")]
        [Column(TypeName = "varchar(255)")]
        public string CategoryName {get; set;}

        //public IEnumerable<SelectListItem> nama { get; set; }
        public CategoryStat CategoryStatus { get; set; }
        public enum CategoryStat
        {
            Published,
            Unpublished
        }
    }
}

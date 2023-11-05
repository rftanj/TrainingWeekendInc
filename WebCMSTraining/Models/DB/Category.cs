using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DB
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        [Column(TypeName = "varchar(255)")]
        public string CategoryName { get; set; }

        [Column(TypeName = "enum('Published', 'Unpublished', 'Trash')")]
        public CategoryStatus Status { get; set; }
        public enum CategoryStatus
        {
            Published,
            Unpublished,
            Trash
        }
    }
}

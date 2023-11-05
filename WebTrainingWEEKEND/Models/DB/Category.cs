using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Models.DB
{
    [Table("categories")]
    public class Category
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string CategoryName {get;set;}

        [Column(TypeName = "enum('Deleted', 'Published')")]
        public CategoryStatus Status { get; set; }
        public enum CategoryStatus
        {
            Published,
            Deleted,
            Trash
        }
    }
}

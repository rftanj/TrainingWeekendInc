using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DTO
{
    public class SuperAdminDTO
    {

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; }
    }
}

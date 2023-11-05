using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DTO
{
    public class RegisterDTO
    {

        [Required(ErrorMessage = "Required!")]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required!")]
        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Column(TypeName = "enum('Published','Unpublished')")]
        public UserIdentityStatus Status { get; set; }
        public enum UserIdentityStatus
        {
            Published,
            Unpublished
        }
    }
}

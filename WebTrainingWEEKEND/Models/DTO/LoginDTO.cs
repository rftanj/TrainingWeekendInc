using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string Password { get; set; }
    }
}

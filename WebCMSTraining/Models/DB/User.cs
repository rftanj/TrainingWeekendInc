using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCMSTraining.Models.DB
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        [Column(TypeName = "enum('Published','Unpublished','Trash')")]
        public UserStatus Status { get; set; }
        public enum UserStatus
        {
            Published,
            Unpublished,
            Trash
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTrainingWEEKEND.Models.DTO
{
    public class CheckResponse
    {
        public bool isError { get; set; }
        public string ErrorMessage { get; set; }
    }
}

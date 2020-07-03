using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Roulette.Core.Entity.DTO
{
    public class BetRequest
    {
        [Required(ErrorMessage = "This field {0} doesn't have the lenght")]
        [Range(0, 36)]
        public Int16 number { get; set; }

        public string color { get; set; }


        [Required]
        [Range(0, 10000)]
        public decimal value { get; set; }
    }
}

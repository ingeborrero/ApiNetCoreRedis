using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Roulette.Core.Entity.DTO
{
    public class BetRequest
    {
        [Required]
        public Int64 IdRoulette { get; set; }

        [Required(ErrorMessage = "This field {0} doesn't have the lenght")]
        [Range(0, 36)]
        public Int16 Number { get; set; }

        [Required]
        public string Color { get; set; }


        [Required]
        [Range(0, 10000)]
        public decimal ValueBet { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core.Entity.Entities
{
    public class Bet
    {
        public Int16 Number { get; set; }
        public string Color { get; set; }
        public decimal ValueBet { get; set; }
        public RouletteEnt Roulette { get; set; }
    }
}

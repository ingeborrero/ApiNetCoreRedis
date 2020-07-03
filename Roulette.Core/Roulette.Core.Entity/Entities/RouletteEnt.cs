using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core.Entity.Entities
{
    public partial class RouletteEnt
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
    }
}

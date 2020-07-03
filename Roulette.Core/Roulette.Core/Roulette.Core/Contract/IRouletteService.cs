using Roulette.Core.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core.Contract
{
    public interface IRouletteService
    {
        Int64 CreateRoulette(string name);
        bool OpenRoulette(Int64 id);
        List<RouletteEnt> GetRoulettes();
    }
}

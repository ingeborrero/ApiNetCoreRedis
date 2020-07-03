using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core.Contract
{
    public interface IRouletteService
    {
        Int64 CreateRoulette(string name);
        string OpenRoulette(string id);
    }
}

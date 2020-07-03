using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core.Contract
{
    public interface IRouletteService
    {
        int CreateRoulette(string name);
        string OpenRoulette(string id);
    }
}

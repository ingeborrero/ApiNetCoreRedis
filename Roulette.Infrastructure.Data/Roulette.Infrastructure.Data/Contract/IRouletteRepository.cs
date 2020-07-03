using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Infrastructure.Data.Contract
{
    public interface IRouletteRepository
    {
        int CreateRoulette(string key, string value);
    }
}

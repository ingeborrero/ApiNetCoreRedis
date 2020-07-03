using Roulette.Core.Entity.DTO;
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
        bool CreateBet(BetRequest betRequest);
        List<Bet> GetBets(Int64 id);
        List<RouletteEnt> GetRoulettes();
    }
}

using Roulette.Core.Contract;
using Roulette.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        
        public RouletteService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }

        public int CreateRoulette(string name)
        {
            return _rouletteRepository.CreateRoulette("ruleta", name);
        }

        public string OpenRoulette(string id)
        {
            throw new NotImplementedException();
        }
    }
}

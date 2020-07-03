using Roulette.Core.Contract;
using Roulette.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Roulette.Core.Entity.Entities;
using Newtonsoft.Json;

namespace Roulette.Core
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        
        public RouletteService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }

        public Int64 CreateRoulette(string name)
        {
            Int64 idNewRoulette = 1;
            var sRoulettes = _rouletteRepository.GetKeysRedis("Roulettes");
            List<RouletteEnt> objRoulettes = new List<RouletteEnt>();  
            if(sRoulettes != null)
            {
                objRoulettes = JsonConvert.DeserializeObject<List<RouletteEnt>>(sRoulettes);
                idNewRoulette = objRoulettes.Count + 1;
            }
            
            var rouletteEntNew = new RouletteEnt 
            { 
                Id = idNewRoulette, 
                Name = name, 
                IsOpen = false
            };
            
            objRoulettes.Add(rouletteEntNew);
            var response = _rouletteRepository.CreateRoulette("Roulettes", JsonConvert.SerializeObject(objRoulettes));

            return idNewRoulette;
        }

        public string OpenRoulette(string id)
        {
            throw new NotImplementedException();
        }
    }
}

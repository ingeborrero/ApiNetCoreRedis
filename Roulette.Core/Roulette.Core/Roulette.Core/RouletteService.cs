using Roulette.Core.Contract;
using Roulette.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Roulette.Core.Entity.Entities;
using Newtonsoft.Json;
using System.Linq;

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

        public bool OpenRoulette(Int64 id)
        {
            var sRoulettes = _rouletteRepository.GetKeysRedis("Roulettes");
            if (sRoulettes == null) return false;
            var objRoulettes = JsonConvert.DeserializeObject<List<RouletteEnt>>(sRoulettes);
            objRoulettes.Where(x => x.Id == id).ToList().ForEach(s => s.IsOpen = true);
            var response = _rouletteRepository.SetKeysRedis("Roulettes", JsonConvert.SerializeObject(objRoulettes));

            return true;
        }

        public List<RouletteEnt> GetRoulettes()
        {
            var sRoulettes = _rouletteRepository.GetKeysRedis("Roulettes");
            if (sRoulettes == null) return null;
            var objRoulettes = JsonConvert.DeserializeObject<List<RouletteEnt>>(sRoulettes);

            return objRoulettes;
        }
    }
}

using Roulette.Core.Contract;
using Roulette.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Roulette.Core.Entity.Entities;
using Newtonsoft.Json;
using System.Linq;
using Roulette.Core.Entity.DTO;

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
            try
            {
                var sRoulettes = _rouletteRepository.GetKeysRedis("Roulettes");
                if (sRoulettes == null) return false;
                var objRoulettes = JsonConvert.DeserializeObject<List<RouletteEnt>>(sRoulettes);
                objRoulettes.Where(x => x.Id == id).ToList().ForEach(s => s.IsOpen = true);
                var response = _rouletteRepository.SetKeysRedis("Roulettes", JsonConvert.SerializeObject(objRoulettes));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool CreateBet(BetRequest betRequest)
        {
            try
            {
                var sBets = _rouletteRepository.GetKeysRedis("Bets");
                List<Bet> objBets = new List<Bet>();
                if (sBets != null)
                {
                    objBets = JsonConvert.DeserializeObject<List<Bet>>(sBets);
                }

                var sRoulettes = _rouletteRepository.GetKeysRedis("Roulettes");
                if (sRoulettes == null) throw new Exception("The Roulette id not exists");
                var objRoulettes = JsonConvert.DeserializeObject<List<RouletteEnt>>(sRoulettes);
                var roulette = objRoulettes.Where(x => x.Id == betRequest.IdRoulette).FirstOrDefault();

                var betNew = new Bet
                {
                    Number = betRequest.Number,
                    Color=betRequest.Color,
                    ValueBet = betRequest.ValueBet,
                    Roulette = roulette
                };
                objBets.Add(betNew);
                var response = _rouletteRepository.SetKeysRedis("Bets", JsonConvert.SerializeObject(objBets));

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public List<Bet> GetBets(Int64 id)
        {
            var sBets = _rouletteRepository.GetKeysRedis("Bets");
            if (sBets == null) return null;
            var objBets = JsonConvert.DeserializeObject<List<Bet>>(sBets);

            var listBeatByRoulette = objBets.Where(x => x.Roulette.Id == id).ToList();

            return listBeatByRoulette;
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

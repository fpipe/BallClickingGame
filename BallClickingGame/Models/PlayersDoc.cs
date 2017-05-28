using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClickingGame.Models
{
    [Serializable]
    public class PlayersDoc
    {
        public List<Player> Players;

        public PlayersDoc()
        {
            Players = new List<Player>();
        }

        public void Add(Player player)
        {
            Players.Add(player);
        }

        //Get all players
        public List<Player> getAllPlayers()
        {
            return Players.Where(player => player.IsActive == true).ToList();
        }

        //Get top 10 players by descending 
        public List<Player> getTop10Players()
        {
            return Players.Where(player => player.IsActive == true)
                .OrderByDescending(player => player.getScore())
                .Take(10).ToList();
        }
        //Get top 1000 players by descending
        public List<Player> getTop1000Players()
        {
            return Players.Where(player => player.IsActive == true)
                .OrderByDescending(player => player.getScore())
                .Take(1000).ToList();
        }
    }
}

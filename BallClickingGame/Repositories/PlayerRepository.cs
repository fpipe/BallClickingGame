using BallClickingGame.Database;
using BallClickingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClickingGame.Repositories
{
    public class PlayerRepository
    {
        private BallClickingGameDatabase db = new BallClickingGameDatabase();
        //Create
        public bool Create(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();

            return true;
        }
        //Get all
        public List<Player> GetAll()
        {
            return db.Players.Where(x => x.IsActive == true).ToList();
        }

        //Get by ID
        public Player GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }
    }
}

using BallClickingGame.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClickingGame.Database
{
    public class BallClickingGameDatabase : DbContext
    {
        public BallClickingGameDatabase() /*: base("SQLConnection")*/ { }

        public DbSet<Player> Players { get; set; }
    }
}

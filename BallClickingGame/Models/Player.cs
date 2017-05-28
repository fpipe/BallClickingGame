using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClickingGame.Models
{
    [Serializable]
    public class Player
    {
        /// <summary>
        ///We need ID to save and search the player in database
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Is player active in database, 
        /// if the player is active in database he will be visible in the scoreboard
        /// </summary>
        public bool IsActive { get; set; }
        private string Name { get; set; }
        private int Score { get; set; }

        public Player(string name, int score, bool isActive)
        {
            Name = name;
            Score = score;
            IsActive = isActive;
        }

        public string getName()
        {
            return this.Name;
        }

        public int getScore()
        {
            return this.Score;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Score);
        }
    }
}

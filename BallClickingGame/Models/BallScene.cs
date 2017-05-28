using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClickingGame.Models
{
    public class BallScene
    {
        public Ball Ball { get; set; }
        public int Width;
        public int Height;
        private int clicks;
        private int misses;

        public BallScene()
        {
            clicks = 0;
            misses = 0;
        }

        public string getScoreText()
        {
            return string.Format("Clicked: {0}; Missed: {1}; Total score: {2}", clicks, misses, getScore());
        }

        public int getClicks()
        {
            return clicks;
        }

        public int getMisses()
        {
            return misses;
        }

        public int getScore()
        {
            return clicks - misses;
        }

        public void AddBall(int formWidth, int formHeight)
        {
            Width = formHeight;
            Height = formWidth;
            Ball = new Ball(Width, Height);
        }

        public void Draw(Graphics g)
        {
            Ball.Draw(g);
        }

        public void Move()
        {
            Ball.Move();
        }

        public void FormResizes(int formWidth, int formHeight)
        {
            Ball.ChangeFormSize(formWidth, formHeight);
        }

        public void checkBallClicked(int x, int y)
        {
            if (Ball.isHit(x, y))
            {
                clicks++;
            }
            else {
                misses++;
            }

        }
    }
}

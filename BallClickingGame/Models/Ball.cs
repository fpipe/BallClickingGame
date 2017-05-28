using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallClickingGame.Models
{
    public class Ball
    {
        public Point Position { get; set; }
        public int Radius { get; set; }
        public static Random Random = new Random();
        public int dx;
        public int dy;
        public int SceneWidth;
        public int SceneHeight;
        private Color Color;

        //Basic Constructor
        public Ball(int formWidth, int formHeight)
        {
            Radius = 30;
            dx = 15;
            dy = 15;
            Color = getColor();
            SceneWidth = formWidth;
            SceneHeight = formHeight;
            int posX = formWidth / 2;
            int posY = formHeight / 2;
            Position = new Point(posX, posY);

        }

        //Get Color for the ball
        private Color getColor()
        {
            return Color.OrangeRed;
        }

        //Drawe the ball on the ball scene
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(getColor());
            g.FillEllipse(brush, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();
        }
        public void ChangeFormSize(int sceneWidth, int sceneHeight)
        {
            SceneWidth = sceneWidth;
            SceneHeight = sceneHeight;
        }

        //Moving the ball around the scene
        public void Move()
        {
            if ((Position.X - Radius < Math.Abs(dx)) ||
                (Position.X + (Radius * 2) + Math.Abs(dx)) > SceneWidth + Math.Abs(dx))
            {
                dx = -dx;
            }
            if ((Position.Y < 80) ||
                (Position.Y + (Radius * 2) + Math.Abs(dy)) > SceneHeight - Math.Abs(dy) - 22)
            {
                dy = -dy;
            }
            Position = new Point(Position.X + dx, Position.Y + dy);
        }

        public bool isHit(int x, int y)
        {
            return ((x - Position.X) * (x - Position.X) + (y - Position.Y) * (y - Position.Y)) <= Radius * Radius;
        }
    }
}

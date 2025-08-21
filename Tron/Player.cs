using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tron
{
    abstract class Player
    {
        public Point location;
        public Size size;
        public Brush brush;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(location, size);
            }
        }
        public Player(Point location_, Size size_, Brush brush_)
        {
            location = location_;
            size = size_;
            brush = brush_;
        }
        public abstract void Draw(Graphics graphics);
        public bool Intersect(Rectangle rect)
        {
            return Rectangle.IntersectsWith(rect);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tron
{
    class Bike : Player
    {
        public Bike(Point location_, Size size_, Brush brush_) : base(location_, size_, brush_)
        {
        }

        public override void Draw(Graphics graphics)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.FillRectangle(brush, new Rectangle(location, size));
        }
    }
}

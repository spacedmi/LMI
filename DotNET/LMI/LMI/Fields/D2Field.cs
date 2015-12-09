using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMI
{
    class D2Field : IField
    {
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private double Q { get; set; }
        private double R { get; set; }

        public D2Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Q = 10.0;
            R = 5.0;
        }

        public void Draw(Graphics graphics)
        {
            int x0 = pictureBoxWidth / 2 - Convert.ToInt32(Q) * 10 - Convert.ToInt32(R) * 10;
            int y0 = pictureBoxHeight / 2 - Convert.ToInt32(R) * 10;
            int d = 2 * Convert.ToInt32(R) * 10;

            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 0, 255, 0));
            graphics.FillEllipse(brush, new Rectangle(x0, y0, d, d));
        }
    }
}

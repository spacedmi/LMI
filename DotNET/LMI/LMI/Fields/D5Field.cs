using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMI
{
    class D5Field : IField
    {
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private double Mu1 { get; set; }
        private double Mu2 { get; set; }

        public D5Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Mu1 = 1.0;
            Mu2 = 7.0;
        }

        public void Draw(Graphics graphics)
        {
            int x = pictureBoxWidth / 2 - Convert.ToInt32(Math.Max(Mu1, Mu2)) * 10;
            int y = 0;
            int width = Convert.ToInt32(Math.Abs(Mu1 - Mu2)) * 10;
            int height = pictureBoxHeight;

            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 0, 255, 255));
            Rectangle rect = new Rectangle(x, y, width, height);
            graphics.FillRectangle(brush, rect);
        }
    }
}

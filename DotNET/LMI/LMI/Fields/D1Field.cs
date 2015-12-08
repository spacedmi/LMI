using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMI
{
    class D1Field : IField
    {
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private double Mu { get; set; }

        public D1Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Mu = 10.0;
        }

        public void Draw(Graphics graphics)
        {
            int x = 0;
            int y = 0;
            int width = pictureBoxWidth / 2 - Convert.ToInt32(Mu);
            int height = pictureBoxHeight;

            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 255, 0, 0));
            Rectangle rect = new Rectangle(0, 0, width, height);
            graphics.FillRectangle(brush, rect);
        }
    }
}

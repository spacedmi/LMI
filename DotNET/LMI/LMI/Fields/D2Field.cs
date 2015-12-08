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
            Q = 1.0;
            R = 5.0;
        }

        public void Draw(Graphics graphics)
        {
            // TODO: D2 Draw
        }
    }
}

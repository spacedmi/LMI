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
            Mu1 = 3.0;
            Mu2 = 6.0;
        }

        public void Draw(Graphics graphics)
        {
            // TODO: D5 Draw
        }
    }
}

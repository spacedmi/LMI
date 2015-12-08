using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMI
{
    class D4Field : IField
    {
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private double Angle { get; set; }

        public D4Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Angle = 30.0;
        }

        public void Draw(Graphics graphics)
        {
            // TODO: D4 Draw
        }
    }
}

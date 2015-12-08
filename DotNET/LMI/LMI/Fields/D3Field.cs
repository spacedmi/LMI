using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMI
{
    class D3Field : IField
    {
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private double Nu { get; set; }

        public D3Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Nu = 5.0;
        }

        public void Draw(Graphics graphics)
        {
            // TODO: D3 Draw
        }
    }
}

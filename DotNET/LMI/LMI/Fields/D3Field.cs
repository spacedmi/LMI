﻿using System;
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
            Nu = 7.0;
        }

        public void Draw(Graphics graphics)
        {
            int x = 0;
            int y = pictureBoxHeight / 2 - Convert.ToInt32(Nu) * 10;
            int width = pictureBoxWidth / 2;
            int height = 2 * Convert.ToInt32(Nu) * 10;

            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 0, 0, 255));
            Rectangle rect = new Rectangle(x, y, width, height);
            graphics.FillRectangle(brush, rect);
        }
    }
}

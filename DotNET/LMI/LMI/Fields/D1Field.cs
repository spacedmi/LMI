﻿using System;
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
        private int pointWidth = 5;
        private int pointHeight = 5;
        private PointF fixPoint { get; set; }
        private float mu;
        private float Mu
        {
            get { return mu; }
            set
            {
                if (value > 0) 
                    mu = value;
                else
                    mu = 0.01f;
                fixPoint = new PointF(-mu, 0.0f);
            }
        }

        public D1Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Mu = 3.0f;
        }

        public void Draw(Graphics graphics)
        {
            int x = 0;
            int y = 0;
            int width = pictureBoxWidth / 2 - Convert.ToInt32(Mu * 10);
            int height = pictureBoxHeight;

            // Draw field
            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 255, 0, 0));
            Rectangle rect = new Rectangle(x, y, width, height);
            graphics.FillRectangle(brush, rect);

            // Draw fixPoint
            SolidBrush fBrush = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
            Rectangle fRect = new Rectangle(
                pictureBoxWidth / 2 + Convert.ToInt32(fixPoint.X * 10) - pointWidth / 2,
                pictureBoxHeight / 2 + Convert.ToInt32(fixPoint.Y * 10) - pointHeight / 2,
                pointWidth,
                pointHeight);
            graphics.FillRectangle(fBrush, fRect);
        }

        public bool isFixPoint(float currentLocationX, float currentLocationY)
        {
            if ((Math.Abs(fixPoint.X - currentLocationX) <=  (float)pointWidth / 20.0f) &&
                (Math.Abs(fixPoint.Y - currentLocationY) <= (float)pointHeight / 20.0f))
                return true;
            else
                return false;

        }

        public void ProcessMousePosition(float currentLocationX, float currentLocationY)
        {
            Mu = -currentLocationX;
        }
    }
}

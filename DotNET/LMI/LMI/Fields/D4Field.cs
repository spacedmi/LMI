using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMI
{
    class D4Field : IField
    {
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private int pointWidth = 5;
        private int pointHeight = 5;
        private float Angle { get; set; }

        public D4Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Angle = 130.0f;
        }

        public void Draw(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 255, 255, 0));
            FillMode fillMode = FillMode.Winding;
            PointF point1 = new PointF(pictureBoxWidth / 2, pictureBoxHeight / 2);
            if (Angle > 90.0)
            {
                PointF point2 = new PointF(0.0F, 0.0F);
                PointF point3 = new PointF(0.0F, pictureBoxHeight);
                PointF point4 = new PointF(0.5F * pictureBoxHeight *
                    (1 - (float)Math.Sqrt(2.0F) * (float)Math.Cos(Math.PI * (Angle / 180.0F) / 2.0F)), 0.0F);
                PointF point5 = new PointF(0.5F * pictureBoxHeight *
                    (1 - (float)Math.Sqrt(2.0F) * (float)Math.Cos(Math.PI * (Angle / 180.0F) / 2.0F)), pictureBoxHeight);
                PointF point6 = new PointF(0.0F, 0.0F);
                PointF point7 = new PointF(0.0F, pictureBoxHeight);
                graphics.FillPolygon(brush, new PointF[9] { point1, point2, point4, point1, point3, point5, point1, point6, point7 }, fillMode);
            }
            else
            {
                var t = Math.PI * (Angle / 180.0F);
                var g = (float)Math.Sin(Math.PI / 4.0F);
                var y = (float)Math.Sin(Math.PI * (Angle / 180.0F) / 2.0F);
                PointF point2 = new PointF(0.0F, 0.5F * (float)pictureBoxHeight * 
                    (1.0F - (float)Math.Sqrt(2.0F) * (float)Math.Sin(Math.PI * (Angle / 180.0F) / 2.0F)));
                PointF point3 = new PointF(0.0F, 0.5F * (float)pictureBoxHeight *
                    (1.0F + (float)Math.Sqrt(2.0F) * (float)Math.Sin(Math.PI * (Angle / 180.0F) / 2.0F)));
                PointF[] curvePoints = { point1, point2, point3 };
                graphics.FillPolygon(brush, new PointF[] { point1, point2, point3 }, fillMode);
            }
        }

        public bool isFixPoint(float currentLocationX, float currentLocationY)
        {
            return false;
        }

        public void ProcessMousePosition(float currentLocationX, float currentLocationY)
        {

        }
    }
}

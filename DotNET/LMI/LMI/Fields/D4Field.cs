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
        private int pointWidth = 6;
        private int pointHeight = 6;
        private PointF fixPoint { get; set; }
        private float angle;
        private float Angle
        {
            get { return angle; }
            set
            {
                if (value > 0.0f)
                    if (value < 180.0f)
                        angle = value;
                    else
                        angle = 179.99f;
                else
                    angle = 0.01f;

                if (angle > 90.0f)
                    fixPoint = new PointF(-(float)pictureBoxHeight / 20.0f *
                    (float)Math.Sqrt(2.0F) * (float)Math.Cos(Math.PI * (Angle / 180.0F) / 2.0F), (float)pictureBoxHeight / 20.0f);
                else
                    fixPoint = new PointF(-(float)pictureBoxHeight / 20.0f, (float)pictureBoxHeight / 20.0f *
                   (float)Math.Sqrt(2.0F) * (float)Math.Sin(Math.PI * (Angle / 180.0F) / 2.0F));
            }
        }

        public D4Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Angle = 100.0f;
        }

        public D4Field(int pictureBoxWidth, int pictureBoxHeight, int angle)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Angle = angle;
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

            // Draw fixPoint
            SolidBrush fBrush = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
            Rectangle fRect = new Rectangle(
                pictureBoxWidth / 2 + Convert.ToInt32(fixPoint.X * 10) - pointWidth / 2,
                pictureBoxHeight / 2 - Convert.ToInt32(fixPoint.Y * 10) - pointHeight / 2,
                pointWidth,
                pointHeight);
            graphics.FillRectangle(fBrush, fRect);
        }

        public bool isFixPoint(float currentLocationX, float currentLocationY)
        {
            if ((Math.Abs(fixPoint.X - currentLocationX) <= (float)pointWidth / 20.0f) &&
                (Math.Abs(fixPoint.Y - currentLocationY) <= (float)pointHeight / 20.0f))
                return true;
            else
                return false;
        }

        public void ProcessMousePosition(float currentLocationX, float currentLocationY)
        {
            if (currentLocationX >= 0)
                Angle = 180.0f;
            else
                Angle = 2.0f * 180.0f / (float)Math.PI * (float)Math.Atan(-currentLocationY / currentLocationX);
        }
    }
}

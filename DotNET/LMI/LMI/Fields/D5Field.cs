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
        private int pointWidth = 6;
        private int pointHeight = 6;
        private PointF fixPointMu1 { get; set; }
        private PointF fixPointMu2 { get; set; }
        private int currentFixPoint = 0;
        private float mu1, mu2;
        private float Mu1
        {
            get { return mu1; }
            set
            {
                if (value > 0)
                    mu1 = value;
                else
                    mu1 = 0.01f;
                fixPointMu1 = new PointF(-mu1, 0.0f);
            }
        }
        private float Mu2
        {
            get { return mu2; }
            set
            {
                if (value > 0)
                    mu2 = value;
                else
                    mu2 = 0.01f;
                fixPointMu2 = new PointF(-mu2, 0.0f);
            }
        }

        public D5Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Mu1 = 1.0f;
            Mu2 = 7.0f;
        }

        public void Draw(Graphics graphics)
        {
            int x = pictureBoxWidth / 2 - Convert.ToInt32(Math.Max(Mu1, Mu2) * 10);
            int y = 0;
            int width = Convert.ToInt32(Math.Abs(Mu1 - Mu2) * 10);
            int height = pictureBoxHeight;

            // Draw field
            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 0, 255, 255));
            Rectangle rect = new Rectangle(x, y, width, height);
            graphics.FillRectangle(brush, rect);

            // Draw fixPointMu1
            SolidBrush fBrushMu1 = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
            Rectangle fRectMu1 = new Rectangle(
                pictureBoxWidth / 2 + Convert.ToInt32(fixPointMu1.X * 10) - pointWidth / 2,
                pictureBoxHeight / 2 - Convert.ToInt32(fixPointMu1.Y * 10) - pointHeight / 2,
                pointWidth,
                pointHeight);
            graphics.FillRectangle(fBrushMu1, fRectMu1);

            // Draw fixPointMu2
            SolidBrush fBrushMu2 = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
            Rectangle fRectMu2 = new Rectangle(
                pictureBoxWidth / 2 + Convert.ToInt32(fixPointMu2.X * 10) - pointWidth / 2,
                pictureBoxHeight / 2 - Convert.ToInt32(fixPointMu2.Y * 10) - pointHeight / 2,
                pointWidth,
                pointHeight);
            graphics.FillRectangle(fBrushMu2, fRectMu2);
        }

        public bool isFixPoint(float currentLocationX, float currentLocationY)
        {
            if ((Math.Abs(fixPointMu1.X - currentLocationX) <= (float)pointWidth / 20.0f) &&
                (Math.Abs(fixPointMu1.Y - currentLocationY) <= (float)pointHeight / 20.0f))
            {
                currentFixPoint = 0;
                return true;
            }

            if ((Math.Abs(fixPointMu2.X - currentLocationX) <= (float)pointWidth / 20.0f) &&
                (Math.Abs(fixPointMu2.Y - currentLocationY) <= (float)pointHeight / 20.0f))
            {
                currentFixPoint = 1;
                return true;
            }
            return false;
        }

        public void ProcessMousePosition(float currentLocationX, float currentLocationY)
        {
            if (currentFixPoint == 0)
                Mu1 = -currentLocationX;
            else
                Mu2 = -currentLocationX;
        }
    }
}

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
        public Field Name = Field.D3Field;
        public float Nu
        {
            get { return nu; }
            set
            {
                if (value > 0)
                    nu = value;
                else
                    nu = 0.01f;
                fixPoint = new PointF(-(float)pictureBoxWidth / 40.0f, nu);
            }
        }

        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private int pointWidth = 6;
        private int pointHeight = 6;
        private PointF fixPoint { get; set; }
        private float nu;

        public D3Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Nu = 7.0f;
        }

        public override void Draw(Graphics graphics)
        {
            int x = 0;
            int y = pictureBoxHeight / 2 - Convert.ToInt32(Nu * 10);
            int width = pictureBoxWidth / 2;
            int height = 2 * Convert.ToInt32(Nu * 10);

            // Draw field
            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 0, 0, 255));
            Rectangle rect = new Rectangle(x, y, width, height);
            graphics.FillRectangle(brush, rect);

            // Draw fixPoint
            SolidBrush fBrush = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
            Rectangle fRect = new Rectangle(
                pictureBoxWidth / 2 + Convert.ToInt32(fixPoint.X * 10) - pointWidth / 2,
                pictureBoxHeight / 2 - Convert.ToInt32(fixPoint.Y * 10) - pointHeight / 2,
                pointWidth,
                pointHeight);
            graphics.FillRectangle(fBrush, fRect);
        }

        public override bool isFixPoint(float currentLocationX, float currentLocationY)
        {
            if ((Math.Abs(fixPoint.X - currentLocationX) <= (float)pointWidth / 20.0f) &&
                (Math.Abs(fixPoint.Y - currentLocationY) <= (float)pointHeight / 20.0f))
                return true;
            else
                return false;
        }

        public override void ProcessMousePosition(float currentLocationX, float currentLocationY)
        {
            Nu = Math.Abs(currentLocationY);
        }
    }
}

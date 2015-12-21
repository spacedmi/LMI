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
        public Field Name = Field.D2Field;
        public float Q 
        {
            get { return q; }
            set
            {
                if (value > 0) 
                    q = value;
                else
                    q = 0.01f;
                fixPointQ = new PointF(-q, 0.0f);
                fixPointR = new PointF(-q, r);
            }
        }
        public float R 
        {
            get { return r; }
            set
            {
                if (value > 1) 
                    r = value;
                else
                    r = 1.00f;
                fixPointR = new PointF(-q, r);
            }
        }

        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private int pointWidth = 6;
        private int pointHeight = 6;
        private PointF fixPointQ { get; set; }
        private PointF fixPointR { get; set; }
        private int currentFixPoint = 0;
        private float q, r;

        public D2Field(int pictureBoxWidth, int pictureBoxHeight)
        {
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
            Q = 10.0f;
            R = 5.0f;
        }

        public override void Draw(Graphics graphics)
        {
            int x0 = pictureBoxWidth * 4 / 5 - Convert.ToInt32(Q * 10) - Convert.ToInt32(R * 10);
            int y0 = pictureBoxHeight / 2 - Convert.ToInt32(R * 10);
            int d = 2 * Convert.ToInt32(R * 10);

            // Draw field
            SolidBrush brush = new SolidBrush(Color.FromArgb(127, 0, 255, 0));
            graphics.FillEllipse(brush, new Rectangle(x0, y0, d, d));

            // Draw fixPointQ
            SolidBrush fBrushQ = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
            Rectangle fRectQ = new Rectangle(
                pictureBoxWidth * 4 / 5 + Convert.ToInt32(fixPointQ.X * 10) - pointWidth / 2,
                pictureBoxHeight / 2 + Convert.ToInt32(fixPointQ.Y * 10) - pointHeight / 2,
                pointWidth,
                pointHeight);
            graphics.FillRectangle(fBrushQ, fRectQ);

            // Draw fixPointR
            SolidBrush fBrushR = new SolidBrush(Color.FromArgb(200, 0, 0, 0));
            Rectangle fRectR = new Rectangle(
                pictureBoxWidth * 4 / 5 + Convert.ToInt32(fixPointR.X * 10) - pointWidth / 2,
                pictureBoxHeight / 2 - Convert.ToInt32(fixPointR.Y * 10) - pointHeight / 2,
                pointWidth,
                pointHeight);
            graphics.FillRectangle(fBrushR, fRectR);
        }

        public override bool isFixPoint(float currentLocationX, float currentLocationY)
        {
            if ((Math.Abs(fixPointQ.X - currentLocationX) <= (float)pointWidth / 20.0f) &&
                (Math.Abs(fixPointQ.Y - currentLocationY) <= (float)pointHeight / 20.0f))
            {
                currentFixPoint = 0;
                return true;
            }

            if ((Math.Abs(fixPointR.X - currentLocationX) <= (float)pointWidth / 20.0f) &&
                (Math.Abs(fixPointR.Y - currentLocationY) <= (float)pointHeight / 20.0f))
            {
                currentFixPoint = 1;
                return true;
            }
            return false;
        }

        public override void ProcessMousePosition(float currentLocationX, float currentLocationY)
        {
            if (currentFixPoint == 0)
                Q = -currentLocationX;
            else
                R = Math.Abs(currentLocationY);
        }
    }
}

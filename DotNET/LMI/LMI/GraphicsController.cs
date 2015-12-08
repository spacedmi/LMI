using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LMI
{
    public class GraphicsController
    {
        public GraphicsController(Graphics graphics, int pictureBoxWidth, int pictureBoxHeight)
        {
            this.graphics = graphics;
            this.pictureBoxWidth = pictureBoxWidth;
            this.pictureBoxHeight = pictureBoxHeight;
        }

        private Graphics graphics;
        private int pictureBoxWidth;
        private int pictureBoxHeight;
        private List<IField> fieldObjects = new List<IField>();

        public int currentPictureBoxLocationX = 0;
        public int currentPictureBoxLocationY = 0;
        public double currentLocationX = 0;
        public double currentLocationY = 0;
        public Field currentFieldName = Field.D1Field;

        public void ProcessMousePosition()
        {
            
        }

        public void AddNewField()
        {
            switch (currentFieldName)
            {
                case Field.D5Field:
                    fieldObjects.Add(new D5Field());
                    break;
                case Field.D4Field:
                    fieldObjects.Add(new D4Field());
                    break;
                case Field.D3Field:
                    fieldObjects.Add(new D3Field());
                    break;
                case Field.D2Field:
                    fieldObjects.Add(new D2Field());
                    break;
                case Field.D1Field:
                default:
                    fieldObjects.Add(new D1Field());
                    break;
            }
        }

        public void Draw()
        {
            // Draw axes
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            graphics.DrawLine(pen, 0, pictureBoxHeight / 2, pictureBoxWidth, pictureBoxHeight / 2);
            graphics.DrawLine(pen, pictureBoxWidth / 2, 0, pictureBoxWidth / 2, pictureBoxHeight);

            foreach (IField fieldObject in fieldObjects)
            {
                fieldObject.Draw(graphics);
            }
        }
    }
}

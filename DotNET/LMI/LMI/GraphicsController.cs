using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using System.IO;

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
        private IField currentFieldObject;
        private List<IField> fieldObjects = new List<IField>();
        private bool isObjectForProcess = false;

        public int currentPictureBoxLocationX = 0;
        public int currentPictureBoxLocationY = 0;
        public float currentLocationX = 0;
        public float currentLocationY = 0;
        public Field currentFieldName = Field.D1Field;

        public void importData(string path)
        {
            path += "fields.json";
            FileInfo fi = new FileInfo(path);
            string fieldsJson = JsonConvert.SerializeObject(fieldObjects);

            using (StreamWriter outfile = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                outfile.Write(fieldsJson);
            }
        }

        public void clear()
        {
            fieldObjects.Clear();
        }

        public void ProcessMousePosition()
        {
            foreach (IField fieldObject in fieldObjects)
            {
                if (fieldObject.isFixPoint(currentLocationX, currentLocationY))
                {
                    isObjectForProcess = true;
                    currentFieldObject = fieldObject;
                }
            }

            if (isObjectForProcess)
            {
                if (currentFieldObject != null)
                {
                    currentFieldObject.ProcessMousePosition(currentLocationX, currentLocationY);
                }
            }
        }

        public void StopProcessMousePosition()
        {
            isObjectForProcess = false;
            currentFieldObject = null;
        }

        public void AddNewField(int angle = 100)
        {
            switch (currentFieldName)
            {
                case Field.D5Field:
                    fieldObjects.Add(new D5Field(pictureBoxWidth, pictureBoxHeight));
                    break;
                case Field.D4Field:
                    fieldObjects.Add(new D4Field(pictureBoxWidth, pictureBoxHeight, angle));
                    break;
                case Field.D3Field:
                    fieldObjects.Add(new D3Field(pictureBoxWidth, pictureBoxHeight));
                    break;
                case Field.D2Field:
                    fieldObjects.Add(new D2Field(pictureBoxWidth, pictureBoxHeight));
                    break;
                case Field.D1Field:
                default:
                    fieldObjects.Add(new D1Field(pictureBoxWidth, pictureBoxHeight));
                    break;
            }
        }

        public void Draw()
        {
            graphics.Clear(Color.White);

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

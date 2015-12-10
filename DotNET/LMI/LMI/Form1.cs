using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMI
{
    public partial class MainForm : Form
    {
        private GraphicsController graphicsController;
        private bool isMouseDown = false;

        public MainForm()
        {
            InitializeComponent();
            graphicsController = new GraphicsController(pictureBox1.CreateGraphics(), pictureBox1.Width, pictureBox1.Height);
            fieldComboBox.SelectedIndex = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            graphicsController.currentPictureBoxLocationX = e.X;
            graphicsController.currentPictureBoxLocationY = e.Y;
            graphicsController.currentLocationX = (float)(e.X - pictureBox1.Width / 2) / 10.0f;
            graphicsController.currentLocationY = (float)(pictureBox1.Height - e.Y - pictureBox1.Height / 2) / 10.0f;

            if (isMouseDown)
            {
                graphicsController.ProcessMousePosition();
                graphicsController.Draw();
            }

            LocationLabel.Text = 
                "Current location: (" + 
                graphicsController.currentLocationX.ToString() + 
                "," +
                graphicsController.currentLocationY.ToString() + 
                ")";
        }

        private void fieldComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (fieldComboBox.SelectedIndex)
            {
                case 4:
                    graphicsController.currentFieldName = Field.D5Field;
                    break;
                case 3:
                    graphicsController.currentFieldName = Field.D4Field;
                    break;
                case 2:
                    graphicsController.currentFieldName = Field.D3Field;
                    break;
                case 1:
                    graphicsController.currentFieldName = Field.D2Field;
                    break;
                case 0:
                default:
                    graphicsController.currentFieldName = Field.D1Field;
                    break;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            graphicsController.StopProcessMousePosition();
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            graphicsController.StopProcessMousePosition();
        }

        private void AddNewFieldButton_Click(object sender, EventArgs e)
        {
            graphicsController.AddNewField();
            graphicsController.Draw();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            label2.Enabled = false;
            angleTextBox.Enabled = false;
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
                    label2.Enabled = false;
                    angleTextBox.Enabled = false;
                    break;
                case 3:
                    graphicsController.currentFieldName = Field.D4Field;
                    label2.Enabled = true;
                    angleTextBox.Enabled = true;
                    break;
                case 2:
                    graphicsController.currentFieldName = Field.D3Field;
                    label2.Enabled = false;
                    angleTextBox.Enabled = false;
                    break;
                case 1:
                    graphicsController.currentFieldName = Field.D2Field;
                    label2.Enabled = false;
                    angleTextBox.Enabled = false;
                    break;
                case 0:
                default:
                    graphicsController.currentFieldName = Field.D1Field;
                    label2.Enabled = false;
                    angleTextBox.Enabled = false;
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
            if (fieldComboBox.SelectedIndex == 3)
                graphicsController.AddNewField(Convert.ToInt32(angleTextBox.Text));
            else
                graphicsController.AddNewField();
            graphicsController.Draw();
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            graphicsController.importData();

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Python27\python.exe";
            start.Arguments = @"..\..\..\..\..\Python\LMI.py";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    answerLabel.Text = "Answer: " + result;
                }
            }
        }
    }
}

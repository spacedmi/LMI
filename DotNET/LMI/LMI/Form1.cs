﻿using System;
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

        public MainForm()
        {
            InitializeComponent();
            graphicsController = new GraphicsController(pictureBox1.CreateGraphics(), pictureBox1.Width, pictureBox1.Height);
            fieldComboBox.SelectedIndex = 0;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            graphicsController.Draw();
            graphicsController.currentPictureBoxLocationX = e.X;
            graphicsController.currentPictureBoxLocationY = e.Y;
            graphicsController.currentLocationX = (double)(e.X - pictureBox1.Width / 2) / 10.0;
            graphicsController.currentLocationY = (double)(pictureBox1.Height - e.Y - pictureBox1.Height / 2) / 10.0;

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
                    graphicsController.currentFieldName = Fields.Field.D5Field;
                    break;
                case 3:
                    graphicsController.currentFieldName = Fields.Field.D4Field;
                    break;
                case 2:
                    graphicsController.currentFieldName = Fields.Field.D3Field;
                    break;
                case 1:
                    graphicsController.currentFieldName = Fields.Field.D2Field;
                    break;
                case 0:
                default:
                    graphicsController.currentFieldName = Fields.Field.D1Field;
                    break;
            }
        }
    }
}

namespace LMI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.fieldComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddNewFieldButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.angleTextBox = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(419, 396);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(108, 13);
            this.LocationLabel.TabIndex = 1;
            this.LocationLabel.Text = "Current location: (0,0)";
            // 
            // fieldComboBox
            // 
            this.fieldComboBox.FormattingEnabled = true;
            this.fieldComboBox.Items.AddRange(new object[] {
            "D1",
            "D2",
            "D3",
            "D4",
            "D5"});
            this.fieldComboBox.Location = new System.Drawing.Point(516, 16);
            this.fieldComboBox.Name = "fieldComboBox";
            this.fieldComboBox.Size = new System.Drawing.Size(44, 21);
            this.fieldComboBox.TabIndex = 2;
            this.fieldComboBox.SelectedIndexChanged += new System.EventHandler(this.fieldComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "New field type:";
            // 
            // AddNewFieldButton
            // 
            this.AddNewFieldButton.Location = new System.Drawing.Point(436, 45);
            this.AddNewFieldButton.Name = "AddNewFieldButton";
            this.AddNewFieldButton.Size = new System.Drawing.Size(124, 23);
            this.AddNewFieldButton.TabIndex = 4;
            this.AddNewFieldButton.Text = "Add new field";
            this.AddNewFieldButton.UseVisualStyleBackColor = true;
            this.AddNewFieldButton.Click += new System.EventHandler(this.AddNewFieldButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Angle:";
            // 
            // angleTextBox
            // 
            this.angleTextBox.Location = new System.Drawing.Point(476, 81);
            this.angleTextBox.Mask = "000";
            this.angleTextBox.Name = "angleTextBox";
            this.angleTextBox.Size = new System.Drawing.Size(44, 20);
            this.angleTextBox.TabIndex = 6;
            this.angleTextBox.Text = "100";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.angleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddNewFieldButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fieldComboBox);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "LMI";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.ComboBox fieldComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddNewFieldButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox angleTextBox;
    }
}


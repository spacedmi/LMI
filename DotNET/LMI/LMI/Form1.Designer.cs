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
            this.solveButton = new System.Windows.Forms.Button();
            this.answerLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(522, 498);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(124, 13);
            this.LocationLabel.TabIndex = 1;
            this.LocationLabel.Text = "Текущая позиция: (0,0)";
            // 
            // fieldComboBox
            // 
            this.fieldComboBox.FormattingEnabled = true;
            this.fieldComboBox.Items.AddRange(new object[] {
            "Левая полуплоскость\t",
            "Круг",
            "Горизонтальная полуполоса",
            "Облась, ограниченная углом\t",
            "Вертикальная полоса"});
            this.fieldComboBox.Location = new System.Drawing.Point(525, 37);
            this.fieldComboBox.Name = "fieldComboBox";
            this.fieldComboBox.Size = new System.Drawing.Size(160, 21);
            this.fieldComboBox.TabIndex = 2;
            this.fieldComboBox.SelectedIndexChanged += new System.EventHandler(this.fieldComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Тип области:";
            // 
            // AddNewFieldButton
            // 
            this.AddNewFieldButton.Location = new System.Drawing.Point(525, 71);
            this.AddNewFieldButton.Name = "AddNewFieldButton";
            this.AddNewFieldButton.Size = new System.Drawing.Size(160, 23);
            this.AddNewFieldButton.TabIndex = 4;
            this.AddNewFieldButton.Text = "Добавить область";
            this.AddNewFieldButton.UseVisualStyleBackColor = true;
            this.AddNewFieldButton.Click += new System.EventHandler(this.AddNewFieldButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Угол:";
            // 
            // angleTextBox
            // 
            this.angleTextBox.Location = new System.Drawing.Point(565, 105);
            this.angleTextBox.Mask = "000";
            this.angleTextBox.Name = "angleTextBox";
            this.angleTextBox.Size = new System.Drawing.Size(44, 20);
            this.angleTextBox.TabIndex = 6;
            this.angleTextBox.Text = "100";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(525, 133);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(160, 23);
            this.solveButton.TabIndex = 7;
            this.solveButton.Text = "Решение";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(528, 197);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(0, 13);
            this.answerLabel.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(525, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 521);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.solveButton);
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
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Button button1;
    }
}


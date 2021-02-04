
namespace OOP_RGR
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.massCounter = new System.Windows.Forms.NumericUpDown();
            this.starCheckBox = new System.Windows.Forms.CheckBox();
            this.orbitCheckBox = new System.Windows.Forms.CheckBox();
            this.doubleCheckBox = new System.Windows.Forms.CheckBox();
            this.massCounter2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.massCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.massCounter2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // massCounter
            // 
            this.massCounter.Location = new System.Drawing.Point(13, 13);
            this.massCounter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.massCounter.Name = "massCounter";
            this.massCounter.Size = new System.Drawing.Size(55, 27);
            this.massCounter.TabIndex = 3;
            // 
            // starCheckBox
            // 
            this.starCheckBox.AutoSize = true;
            this.starCheckBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.starCheckBox.Location = new System.Drawing.Point(74, 12);
            this.starCheckBox.Name = "starCheckBox";
            this.starCheckBox.Size = new System.Drawing.Size(78, 24);
            this.starCheckBox.TabIndex = 4;
            this.starCheckBox.Text = "Звезда";
            this.starCheckBox.UseVisualStyleBackColor = true;
            // 
            // orbitCheckBox
            // 
            this.orbitCheckBox.AutoSize = true;
            this.orbitCheckBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.orbitCheckBox.Location = new System.Drawing.Point(74, 42);
            this.orbitCheckBox.Name = "orbitCheckBox";
            this.orbitCheckBox.Size = new System.Drawing.Size(153, 24);
            this.orbitCheckBox.TabIndex = 5;
            this.orbitCheckBox.Text = "Запуск по орбите";
            this.orbitCheckBox.UseVisualStyleBackColor = true;
            // 
            // doubleCheckBox
            // 
            this.doubleCheckBox.AutoSize = true;
            this.doubleCheckBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.doubleCheckBox.Location = new System.Drawing.Point(74, 72);
            this.doubleCheckBox.Name = "doubleCheckBox";
            this.doubleCheckBox.Size = new System.Drawing.Size(146, 24);
            this.doubleCheckBox.TabIndex = 6;
            this.doubleCheckBox.Text = "Двойной объект";
            this.doubleCheckBox.UseVisualStyleBackColor = true;
            this.doubleCheckBox.CheckedChanged += new System.EventHandler(this.doubleCheckBox_CheckedChanged);
            // 
            // massCounter2
            // 
            this.massCounter2.Location = new System.Drawing.Point(13, 46);
            this.massCounter2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.massCounter2.Name = "massCounter2";
            this.massCounter2.Size = new System.Drawing.Size(55, 27);
            this.massCounter2.TabIndex = 7;
            this.massCounter2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(933, 507);
            this.Controls.Add(this.massCounter2);
            this.Controls.Add(this.doubleCheckBox);
            this.Controls.Add(this.orbitCheckBox);
            this.Controls.Add(this.starCheckBox);
            this.Controls.Add(this.massCounter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.massCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.massCounter2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown massCounter;
        private System.Windows.Forms.CheckBox starCheckBox;
        private System.Windows.Forms.CheckBox orbitCheckBox;
        private System.Windows.Forms.CheckBox doubleCheckBox;
        private System.Windows.Forms.NumericUpDown massCounter2;
    }
}



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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.massCounter = new System.Windows.Forms.NumericUpDown();
            this.starCheckBox = new System.Windows.Forms.CheckBox();
            this.orbitCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.massCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // massCounter
            // 
            this.massCounter.Location = new System.Drawing.Point(13, 13);
            this.massCounter.Name = "massCounter";
            this.massCounter.Size = new System.Drawing.Size(55, 27);
            this.massCounter.TabIndex = 3;
            // 
            // starCheckBox
            // 
            this.starCheckBox.AutoSize = true;
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
            this.orbitCheckBox.Location = new System.Drawing.Point(74, 42);
            this.orbitCheckBox.Name = "orbitCheckBox";
            this.orbitCheckBox.Size = new System.Drawing.Size(153, 24);
            this.orbitCheckBox.TabIndex = 5;
            this.orbitCheckBox.Text = "Запуск по орбите";
            this.orbitCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 507);
            this.Controls.Add(this.orbitCheckBox);
            this.Controls.Add(this.starCheckBox);
            this.Controls.Add(this.massCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.massCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown massCounter;
        private System.Windows.Forms.CheckBox starCheckBox;
        private System.Windows.Forms.CheckBox orbitCheckBox;
    }
}


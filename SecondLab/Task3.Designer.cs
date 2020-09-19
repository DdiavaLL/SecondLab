namespace SecondLab
{
    partial class Task3
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
            this.h_trackBar = new System.Windows.Forms.TrackBar();
            this.s_trackBar = new System.Windows.Forms.TrackBar();
            this.v_trackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.h_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // h_trackBar
            // 
            this.h_trackBar.Location = new System.Drawing.Point(53, 268);
            this.h_trackBar.Maximum = 360;
            this.h_trackBar.Minimum = -360;
            this.h_trackBar.Name = "h_trackBar";
            this.h_trackBar.Size = new System.Drawing.Size(266, 45);
            this.h_trackBar.TabIndex = 0;
            // 
            // s_trackBar
            // 
            this.s_trackBar.Location = new System.Drawing.Point(53, 319);
            this.s_trackBar.Maximum = 100;
            this.s_trackBar.Minimum = -100;
            this.s_trackBar.Name = "s_trackBar";
            this.s_trackBar.Size = new System.Drawing.Size(266, 45);
            this.s_trackBar.TabIndex = 1;
            // 
            // v_trackBar
            // 
            this.v_trackBar.Location = new System.Drawing.Point(53, 371);
            this.v_trackBar.Maximum = 100;
            this.v_trackBar.Minimum = -100;
            this.v_trackBar.Name = "v_trackBar";
            this.v_trackBar.Size = new System.Drawing.Size(265, 45);
            this.v_trackBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "S";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "V";
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadButton.Location = new System.Drawing.Point(26, 43);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(186, 34);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Загрузить изображение";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(26, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "Применить изменения";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(416, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 288);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(26, 154);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(186, 54);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить изображение";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.v_trackBar);
            this.Controls.Add(this.s_trackBar);
            this.Controls.Add(this.h_trackBar);
            this.Name = "Task3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task3";
            ((System.ComponentModel.ISupportInitialize)(this.h_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar h_trackBar;
        private System.Windows.Forms.TrackBar s_trackBar;
        private System.Windows.Forms.TrackBar v_trackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button saveButton;
    }
}
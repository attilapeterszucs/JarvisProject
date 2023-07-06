namespace Jarvis
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Log = new System.Windows.Forms.RichTextBox();
            this.LogBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.offline = new System.Windows.Forms.Label();
            this.CameraBox = new System.Windows.Forms.PictureBox();
            this.DetectedImageBox = new System.Windows.Forms.PictureBox();
            this.Camera_Label = new System.Windows.Forms.Label();
            this.Captured_Label = new System.Windows.Forms.Label();
            this.Name_Label = new System.Windows.Forms.Label();
            this.FaceName_TextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetectedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.SystemColors.MenuText;
            this.Log.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Log.Location = new System.Drawing.Point(12, 12);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(224, 542);
            this.Log.TabIndex = 0;
            this.Log.Text = "- Log -";
            this.Log.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // LogBtn
            // 
            this.LogBtn.Location = new System.Drawing.Point(646, 531);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(114, 23);
            this.LogBtn.TabIndex = 2;
            this.LogBtn.Text = "Show/Hide Log";
            this.LogBtn.UseVisualStyleBackColor = true;
            this.LogBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Jarvis.Properties.Resources.Jarvis;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 587);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // offline
            // 
            this.offline.AutoSize = true;
            this.offline.BackColor = System.Drawing.Color.Transparent;
            this.offline.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offline.Location = new System.Drawing.Point(378, 252);
            this.offline.Name = "offline";
            this.offline.Size = new System.Drawing.Size(237, 37);
            this.offline.TabIndex = 4;
            this.offline.Text = "System Offline";
            // 
            // CameraBox
            // 
            this.CameraBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.CameraBox.Location = new System.Drawing.Point(242, 32);
            this.CameraBox.Name = "CameraBox";
            this.CameraBox.Size = new System.Drawing.Size(327, 262);
            this.CameraBox.TabIndex = 5;
            this.CameraBox.TabStop = false;
            this.CameraBox.Visible = false;
            // 
            // DetectedImageBox
            // 
            this.DetectedImageBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.DetectedImageBox.Location = new System.Drawing.Point(575, 74);
            this.DetectedImageBox.Name = "DetectedImageBox";
            this.DetectedImageBox.Size = new System.Drawing.Size(146, 144);
            this.DetectedImageBox.TabIndex = 6;
            this.DetectedImageBox.TabStop = false;
            this.DetectedImageBox.Visible = false;
            // 
            // Camera_Label
            // 
            this.Camera_Label.AutoSize = true;
            this.Camera_Label.BackColor = System.Drawing.Color.DarkGray;
            this.Camera_Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Camera_Label.Location = new System.Drawing.Point(242, 14);
            this.Camera_Label.Name = "Camera_Label";
            this.Camera_Label.Size = new System.Drawing.Size(49, 15);
            this.Camera_Label.TabIndex = 7;
            this.Camera_Label.Text = "CAMERA";
            this.Camera_Label.Visible = false;
            // 
            // Captured_Label
            // 
            this.Captured_Label.AutoSize = true;
            this.Captured_Label.BackColor = System.Drawing.Color.DarkGray;
            this.Captured_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Captured_Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Captured_Label.Location = new System.Drawing.Point(575, 56);
            this.Captured_Label.Name = "Captured_Label";
            this.Captured_Label.Size = new System.Drawing.Size(63, 15);
            this.Captured_Label.TabIndex = 8;
            this.Captured_Label.Text = "CAPTURED";
            this.Captured_Label.Visible = false;
            // 
            // Name_Label
            // 
            this.Name_Label.AutoSize = true;
            this.Name_Label.BackColor = System.Drawing.Color.DarkGray;
            this.Name_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Name_Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name_Label.Location = new System.Drawing.Point(575, 221);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(42, 15);
            this.Name_Label.TabIndex = 9;
            this.Name_Label.Text = "NAME:";
            this.Name_Label.Visible = false;
            this.Name_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // FaceName_TextBox
            // 
            this.FaceName_TextBox.BackColor = System.Drawing.Color.White;
            this.FaceName_TextBox.Location = new System.Drawing.Point(623, 219);
            this.FaceName_TextBox.Name = "FaceName_TextBox";
            this.FaceName_TextBox.Size = new System.Drawing.Size(98, 20);
            this.FaceName_TextBox.TabIndex = 10;
            this.FaceName_TextBox.Visible = false;
            this.FaceName_TextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(772, 566);
            this.Controls.Add(this.FaceName_TextBox);
            this.Controls.Add(this.Name_Label);
            this.Controls.Add(this.Captured_Label);
            this.Controls.Add(this.Camera_Label);
            this.Controls.Add(this.DetectedImageBox);
            this.Controls.Add(this.CameraBox);
            this.Controls.Add(this.LogBtn);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.offline);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Jarvis (Beta 5.0)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetectedImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.Button LogBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label offline;
        private System.Windows.Forms.PictureBox CameraBox;
        private System.Windows.Forms.PictureBox DetectedImageBox;
        private System.Windows.Forms.Label Camera_Label;
        private System.Windows.Forms.Label Captured_Label;
        private System.Windows.Forms.Label Name_Label;
        private System.Windows.Forms.TextBox FaceName_TextBox;
    }
}


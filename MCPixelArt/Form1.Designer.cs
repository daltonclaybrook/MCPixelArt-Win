namespace MCPixelArt
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
            this.imageWell = new System.Windows.Forms.PictureBox();
            this.instructLabel = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.sizeSlider = new System.Windows.Forms.TrackBar();
            this.staticSizeLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.imageWell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // imageWell
            // 
            this.imageWell.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageWell.Location = new System.Drawing.Point(12, 12);
            this.imageWell.Name = "imageWell";
            this.imageWell.Size = new System.Drawing.Size(260, 166);
            this.imageWell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageWell.TabIndex = 0;
            this.imageWell.TabStop = false;
            // 
            // instructLabel
            // 
            this.instructLabel.AutoSize = true;
            this.instructLabel.Enabled = false;
            this.instructLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.instructLabel.Location = new System.Drawing.Point(85, 87);
            this.instructLabel.Name = "instructLabel";
            this.instructLabel.Size = new System.Drawing.Size(116, 17);
            this.instructLabel.TabIndex = 1;
            this.instructLabel.Text = "Drop in an Image";
            // 
            // previewButton
            // 
            this.previewButton.Enabled = false;
            this.previewButton.Location = new System.Drawing.Point(12, 226);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(260, 29);
            this.previewButton.TabIndex = 2;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // sizeSlider
            // 
            this.sizeSlider.Location = new System.Drawing.Point(12, 201);
            this.sizeSlider.Maximum = 0;
            this.sizeSlider.Name = "sizeSlider";
            this.sizeSlider.Size = new System.Drawing.Size(260, 45);
            this.sizeSlider.TabIndex = 3;
            this.sizeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sizeSlider.Scroll += new System.EventHandler(this.sizeSlider_Scroll);
            // 
            // staticSizeLabel
            // 
            this.staticSizeLabel.AutoSize = true;
            this.staticSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staticSizeLabel.Location = new System.Drawing.Point(12, 181);
            this.staticSizeLabel.Name = "staticSizeLabel";
            this.staticSizeLabel.Size = new System.Drawing.Size(39, 17);
            this.staticSizeLabel.TabIndex = 4;
            this.staticSizeLabel.Text = "Size:";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLabel.Location = new System.Drawing.Point(57, 181);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(38, 17);
            this.sizeLabel.TabIndex = 5;
            this.sizeLabel.Text = "0 x 0";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 201);
            this.progressBar.MarqueeAnimationSpeed = 50;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(260, 21);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 263);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.staticSizeLabel);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.sizeSlider);
            this.Controls.Add(this.instructLabel);
            this.Controls.Add(this.imageWell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 305);
            this.MinimumSize = new System.Drawing.Size(300, 305);
            this.Name = "Form1";
            this.Text = "MCPixelArt";
            ((System.ComponentModel.ISupportInitialize)(this.imageWell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageWell;
        private System.Windows.Forms.Label instructLabel;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.TrackBar sizeSlider;
        private System.Windows.Forms.Label staticSizeLabel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}


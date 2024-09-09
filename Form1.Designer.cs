namespace CS_NEA_Interactive
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
            this.background = new System.Windows.Forms.Panel();
            this.MNISTDatasetInputPictureBox = new System.Windows.Forms.PictureBox();
            this.reloadTrainingImagesButton = new System.Windows.Forms.Button();
            this.userInputLabel = new System.Windows.Forms.Label();
            this.mnistDatasetInputLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MNISTDatasetInputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.White;
            this.background.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.background.Location = new System.Drawing.Point(12, 12);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(280, 280);
            this.background.TabIndex = 0;
            this.background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.background.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.background.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // MNISTDatasetInputPictureBox
            // 
            this.MNISTDatasetInputPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MNISTDatasetInputPictureBox.ImageLocation = "D:\\0.College\\Computer Science\\programs\\CS-NEA-Interactive\\bin\\Debug\\trainingImage" +
    "0.Bmp";
            this.MNISTDatasetInputPictureBox.Location = new System.Drawing.Point(298, 12);
            this.MNISTDatasetInputPictureBox.Name = "MNISTDatasetInputPictureBox";
            this.MNISTDatasetInputPictureBox.Size = new System.Drawing.Size(280, 280);
            this.MNISTDatasetInputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MNISTDatasetInputPictureBox.TabIndex = 1;
            this.MNISTDatasetInputPictureBox.TabStop = false;
            // 
            // reloadTrainingImagesButton
            // 
            this.reloadTrainingImagesButton.Location = new System.Drawing.Point(442, 295);
            this.reloadTrainingImagesButton.Name = "reloadTrainingImagesButton";
            this.reloadTrainingImagesButton.Size = new System.Drawing.Size(136, 27);
            this.reloadTrainingImagesButton.TabIndex = 2;
            this.reloadTrainingImagesButton.Text = "Reload Training Images";
            this.reloadTrainingImagesButton.UseVisualStyleBackColor = true;
            this.reloadTrainingImagesButton.Click += new System.EventHandler(this.reloadTrainingImagesButton_Click);
            // 
            // userInputLabel
            // 
            this.userInputLabel.AutoSize = true;
            this.userInputLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.userInputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userInputLabel.Location = new System.Drawing.Point(12, 295);
            this.userInputLabel.Name = "userInputLabel";
            this.userInputLabel.Size = new System.Drawing.Size(67, 15);
            this.userInputLabel.TabIndex = 3;
            this.userInputLabel.Text = "User Input ^";
            // 
            // mnistDatasetInputLabel
            // 
            this.mnistDatasetInputLabel.AutoSize = true;
            this.mnistDatasetInputLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mnistDatasetInputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mnistDatasetInputLabel.Location = new System.Drawing.Point(298, 295);
            this.mnistDatasetInputLabel.Name = "mnistDatasetInputLabel";
            this.mnistDatasetInputLabel.Size = new System.Drawing.Size(119, 15);
            this.mnistDatasetInputLabel.TabIndex = 4;
            this.mnistDatasetInputLabel.Text = "MNIST Dataset Input ^";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(588, 327);
            this.Controls.Add(this.mnistDatasetInputLabel);
            this.Controls.Add(this.userInputLabel);
            this.Controls.Add(this.reloadTrainingImagesButton);
            this.Controls.Add(this.MNISTDatasetInputPictureBox);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Digit Recognition App";
            ((System.ComponentModel.ISupportInitialize)(this.MNISTDatasetInputPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel background;
        private System.Windows.Forms.PictureBox MNISTDatasetInputPictureBox;
        private System.Windows.Forms.Button reloadTrainingImagesButton;
        private System.Windows.Forms.Label userInputLabel;
        private System.Windows.Forms.Label mnistDatasetInputLabel;
    }
}


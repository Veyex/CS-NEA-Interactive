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
            this.newNetworkButton = new System.Windows.Forms.Button();
            this.loadNetworkButton = new System.Windows.Forms.Button();
            this.andGateCheckbox = new System.Windows.Forms.CheckBox();
            this.xorGateCheckbox = new System.Windows.Forms.CheckBox();
            this.mnistBinCheckbox = new System.Windows.Forms.CheckBox();
            this.mnistQuadCheckbox = new System.Windows.Forms.CheckBox();
            this.trainNetworkButton = new System.Windows.Forms.Button();
            this.chooseTrainingDataLabel = new System.Windows.Forms.Label();
            this.mnistFullCheckbox = new System.Windows.Forms.CheckBox();
            this.networkFilePathInput = new System.Windows.Forms.TextBox();
            this.networkFilePathLabel = new System.Windows.Forms.Label();
            this.networkTestButton = new System.Windows.Forms.Button();
            this.createNewNetworkBackground = new System.Windows.Forms.PictureBox();
            this.loadNetworkBackground = new System.Windows.Forms.PictureBox();
            this.netLayoutInput = new System.Windows.Forms.TextBox();
            this.netLayoutLabel = new System.Windows.Forms.Label();
            this.learnRateLabel = new System.Windows.Forms.Label();
            this.learnRateInput = new System.Windows.Forms.TextBox();
            this.inputLengthLabel = new System.Windows.Forms.Label();
            this.inputLengthInput = new System.Windows.Forms.TextBox();
            this.trainNetworkBackground = new System.Windows.Forms.PictureBox();
            this.loadTrainingDataButton = new System.Windows.Forms.Button();
            this.epochsLabel = new System.Windows.Forms.Label();
            this.epochsInput = new System.Windows.Forms.TextBox();
            this.saveNetworkButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sampleSizeTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MNISTDatasetInputPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createNewNetworkBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadNetworkBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainNetworkBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.White;
            this.background.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.background.Location = new System.Drawing.Point(332, 12);
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
            this.MNISTDatasetInputPictureBox.ImageLocation = "D:\\0.College\\Computer Science\\programs\\CS-NEA-Interactive\\bin\\Debug\\images/9/trai" +
    "ningImage45.Bmp";
            this.MNISTDatasetInputPictureBox.Location = new System.Drawing.Point(624, 11);
            this.MNISTDatasetInputPictureBox.Name = "MNISTDatasetInputPictureBox";
            this.MNISTDatasetInputPictureBox.Size = new System.Drawing.Size(280, 280);
            this.MNISTDatasetInputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MNISTDatasetInputPictureBox.TabIndex = 1;
            this.MNISTDatasetInputPictureBox.TabStop = false;
            // 
            // reloadTrainingImagesButton
            // 
            this.reloadTrainingImagesButton.Location = new System.Drawing.Point(638, 292);
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
            this.userInputLabel.Location = new System.Drawing.Point(333, 295);
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
            this.mnistDatasetInputLabel.Location = new System.Drawing.Point(782, 292);
            this.mnistDatasetInputLabel.Name = "mnistDatasetInputLabel";
            this.mnistDatasetInputLabel.Size = new System.Drawing.Size(119, 15);
            this.mnistDatasetInputLabel.TabIndex = 4;
            this.mnistDatasetInputLabel.Text = "MNIST Dataset Input ^";
            // 
            // newNetworkButton
            // 
            this.newNetworkButton.Location = new System.Drawing.Point(20, 22);
            this.newNetworkButton.Name = "newNetworkButton";
            this.newNetworkButton.Size = new System.Drawing.Size(127, 27);
            this.newNetworkButton.TabIndex = 5;
            this.newNetworkButton.Text = "Create New Network";
            this.newNetworkButton.UseVisualStyleBackColor = true;
            this.newNetworkButton.Click += new System.EventHandler(this.newNetworkButton_Click);
            // 
            // loadNetworkButton
            // 
            this.loadNetworkButton.Location = new System.Drawing.Point(20, 201);
            this.loadNetworkButton.Name = "loadNetworkButton";
            this.loadNetworkButton.Size = new System.Drawing.Size(127, 27);
            this.loadNetworkButton.TabIndex = 6;
            this.loadNetworkButton.Text = "Load Network";
            this.loadNetworkButton.UseVisualStyleBackColor = true;
            this.loadNetworkButton.Click += new System.EventHandler(this.loadNetworkButton_Click);
            // 
            // andGateCheckbox
            // 
            this.andGateCheckbox.AutoSize = true;
            this.andGateCheckbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.andGateCheckbox.Location = new System.Drawing.Point(202, 43);
            this.andGateCheckbox.Name = "andGateCheckbox";
            this.andGateCheckbox.Size = new System.Drawing.Size(75, 17);
            this.andGateCheckbox.TabIndex = 7;
            this.andGateCheckbox.Text = "AND Gate";
            this.andGateCheckbox.UseVisualStyleBackColor = false;
            this.andGateCheckbox.CheckedChanged += new System.EventHandler(this.andGateCheckbox_CheckedChanged);
            // 
            // xorGateCheckbox
            // 
            this.xorGateCheckbox.AutoSize = true;
            this.xorGateCheckbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xorGateCheckbox.Checked = true;
            this.xorGateCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xorGateCheckbox.Cursor = System.Windows.Forms.Cursors.Default;
            this.xorGateCheckbox.Location = new System.Drawing.Point(202, 66);
            this.xorGateCheckbox.Name = "xorGateCheckbox";
            this.xorGateCheckbox.Size = new System.Drawing.Size(75, 17);
            this.xorGateCheckbox.TabIndex = 8;
            this.xorGateCheckbox.Text = "XOR Gate";
            this.xorGateCheckbox.UseVisualStyleBackColor = false;
            this.xorGateCheckbox.CheckedChanged += new System.EventHandler(this.xorGateCheckbox_CheckedChanged);
            // 
            // mnistBinCheckbox
            // 
            this.mnistBinCheckbox.AutoSize = true;
            this.mnistBinCheckbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnistBinCheckbox.Location = new System.Drawing.Point(202, 89);
            this.mnistBinCheckbox.Name = "mnistBinCheckbox";
            this.mnistBinCheckbox.Size = new System.Drawing.Size(92, 17);
            this.mnistBinCheckbox.TabIndex = 9;
            this.mnistBinCheckbox.Text = "Binary MNIST";
            this.mnistBinCheckbox.UseVisualStyleBackColor = false;
            this.mnistBinCheckbox.CheckedChanged += new System.EventHandler(this.mnistBinCheckbox_CheckedChanged);
            // 
            // mnistQuadCheckbox
            // 
            this.mnistQuadCheckbox.AutoSize = true;
            this.mnistQuadCheckbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnistQuadCheckbox.Location = new System.Drawing.Point(202, 112);
            this.mnistQuadCheckbox.Name = "mnistQuadCheckbox";
            this.mnistQuadCheckbox.Size = new System.Drawing.Size(89, 17);
            this.mnistQuadCheckbox.TabIndex = 10;
            this.mnistQuadCheckbox.Text = "Quad MNIST";
            this.mnistQuadCheckbox.UseVisualStyleBackColor = false;
            this.mnistQuadCheckbox.CheckedChanged += new System.EventHandler(this.mnistQuadCheckbox_CheckedChanged);
            // 
            // trainNetworkButton
            // 
            this.trainNetworkButton.Location = new System.Drawing.Point(181, 275);
            this.trainNetworkButton.Name = "trainNetworkButton";
            this.trainNetworkButton.Size = new System.Drawing.Size(127, 27);
            this.trainNetworkButton.TabIndex = 11;
            this.trainNetworkButton.Text = "Train Network";
            this.trainNetworkButton.UseVisualStyleBackColor = true;
            this.trainNetworkButton.Click += new System.EventHandler(this.trainNetworkButton_Click);
            // 
            // chooseTrainingDataLabel
            // 
            this.chooseTrainingDataLabel.AutoSize = true;
            this.chooseTrainingDataLabel.BackColor = System.Drawing.SystemColors.Control;
            this.chooseTrainingDataLabel.Location = new System.Drawing.Point(188, 23);
            this.chooseTrainingDataLabel.Name = "chooseTrainingDataLabel";
            this.chooseTrainingDataLabel.Size = new System.Drawing.Size(113, 13);
            this.chooseTrainingDataLabel.TabIndex = 12;
            this.chooseTrainingDataLabel.Text = "Choose Training Data:";
            // 
            // mnistFullCheckbox
            // 
            this.mnistFullCheckbox.AutoSize = true;
            this.mnistFullCheckbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnistFullCheckbox.Location = new System.Drawing.Point(202, 135);
            this.mnistFullCheckbox.Name = "mnistFullCheckbox";
            this.mnistFullCheckbox.Size = new System.Drawing.Size(79, 17);
            this.mnistFullCheckbox.TabIndex = 13;
            this.mnistFullCheckbox.Text = "Full MNIST";
            this.mnistFullCheckbox.UseVisualStyleBackColor = false;
            this.mnistFullCheckbox.CheckedChanged += new System.EventHandler(this.mnistFullCheckbox_CheckedChanged);
            // 
            // networkFilePathInput
            // 
            this.networkFilePathInput.Location = new System.Drawing.Point(27, 281);
            this.networkFilePathInput.Name = "networkFilePathInput";
            this.networkFilePathInput.Size = new System.Drawing.Size(110, 20);
            this.networkFilePathInput.TabIndex = 14;
            this.networkFilePathInput.Text = "xorNet.txt";
            // 
            // networkFilePathLabel
            // 
            this.networkFilePathLabel.AutoSize = true;
            this.networkFilePathLabel.Location = new System.Drawing.Point(36, 266);
            this.networkFilePathLabel.Name = "networkFilePathLabel";
            this.networkFilePathLabel.Size = new System.Drawing.Size(94, 13);
            this.networkFilePathLabel.TabIndex = 15;
            this.networkFilePathLabel.Text = "Network File Path:";
            // 
            // networkTestButton
            // 
            this.networkTestButton.Location = new System.Drawing.Point(406, 292);
            this.networkTestButton.Name = "networkTestButton";
            this.networkTestButton.Size = new System.Drawing.Size(95, 27);
            this.networkTestButton.TabIndex = 16;
            this.networkTestButton.Text = "Test Network";
            this.networkTestButton.UseVisualStyleBackColor = true;
            this.networkTestButton.Click += new System.EventHandler(this.networkTestButton_Click);
            // 
            // createNewNetworkBackground
            // 
            this.createNewNetworkBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.createNewNetworkBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.createNewNetworkBackground.Location = new System.Drawing.Point(11, 12);
            this.createNewNetworkBackground.Name = "createNewNetworkBackground";
            this.createNewNetworkBackground.Size = new System.Drawing.Size(149, 172);
            this.createNewNetworkBackground.TabIndex = 17;
            this.createNewNetworkBackground.TabStop = false;
            // 
            // loadNetworkBackground
            // 
            this.loadNetworkBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.loadNetworkBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadNetworkBackground.Location = new System.Drawing.Point(11, 193);
            this.loadNetworkBackground.Name = "loadNetworkBackground";
            this.loadNetworkBackground.Size = new System.Drawing.Size(149, 119);
            this.loadNetworkBackground.TabIndex = 18;
            this.loadNetworkBackground.TabStop = false;
            // 
            // netLayoutInput
            // 
            this.netLayoutInput.Location = new System.Drawing.Point(30, 69);
            this.netLayoutInput.Name = "netLayoutInput";
            this.netLayoutInput.Size = new System.Drawing.Size(110, 20);
            this.netLayoutInput.TabIndex = 19;
            this.netLayoutInput.Text = "2,1";
            // 
            // netLayoutLabel
            // 
            this.netLayoutLabel.AutoSize = true;
            this.netLayoutLabel.Location = new System.Drawing.Point(43, 54);
            this.netLayoutLabel.Name = "netLayoutLabel";
            this.netLayoutLabel.Size = new System.Drawing.Size(85, 13);
            this.netLayoutLabel.TabIndex = 20;
            this.netLayoutLabel.Text = "Network Layout:";
            // 
            // learnRateLabel
            // 
            this.learnRateLabel.AutoSize = true;
            this.learnRateLabel.Location = new System.Drawing.Point(53, 96);
            this.learnRateLabel.Name = "learnRateLabel";
            this.learnRateLabel.Size = new System.Drawing.Size(63, 13);
            this.learnRateLabel.TabIndex = 22;
            this.learnRateLabel.Text = "Learn Rate:";
            // 
            // learnRateInput
            // 
            this.learnRateInput.Location = new System.Drawing.Point(30, 111);
            this.learnRateInput.Name = "learnRateInput";
            this.learnRateInput.Size = new System.Drawing.Size(110, 20);
            this.learnRateInput.TabIndex = 21;
            this.learnRateInput.Text = "0.2";
            this.learnRateInput.TextChanged += new System.EventHandler(this.learnRateInput_TextChanged);
            // 
            // inputLengthLabel
            // 
            this.inputLengthLabel.AutoSize = true;
            this.inputLengthLabel.Location = new System.Drawing.Point(53, 139);
            this.inputLengthLabel.Name = "inputLengthLabel";
            this.inputLengthLabel.Size = new System.Drawing.Size(70, 13);
            this.inputLengthLabel.TabIndex = 24;
            this.inputLengthLabel.Text = "Input Length:";
            // 
            // inputLengthInput
            // 
            this.inputLengthInput.Location = new System.Drawing.Point(30, 154);
            this.inputLengthInput.Name = "inputLengthInput";
            this.inputLengthInput.Size = new System.Drawing.Size(110, 20);
            this.inputLengthInput.TabIndex = 23;
            this.inputLengthInput.Text = "2";
            // 
            // trainNetworkBackground
            // 
            this.trainNetworkBackground.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trainNetworkBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trainNetworkBackground.Location = new System.Drawing.Point(171, 12);
            this.trainNetworkBackground.Name = "trainNetworkBackground";
            this.trainNetworkBackground.Size = new System.Drawing.Size(149, 300);
            this.trainNetworkBackground.TabIndex = 25;
            this.trainNetworkBackground.TabStop = false;
            // 
            // loadTrainingDataButton
            // 
            this.loadTrainingDataButton.Location = new System.Drawing.Point(181, 157);
            this.loadTrainingDataButton.Name = "loadTrainingDataButton";
            this.loadTrainingDataButton.Size = new System.Drawing.Size(127, 27);
            this.loadTrainingDataButton.TabIndex = 26;
            this.loadTrainingDataButton.Text = "Load Training Data";
            this.loadTrainingDataButton.UseVisualStyleBackColor = true;
            this.loadTrainingDataButton.Click += new System.EventHandler(this.loadTrainingDataButton_Click);
            // 
            // epochsLabel
            // 
            this.epochsLabel.AutoSize = true;
            this.epochsLabel.Location = new System.Drawing.Point(219, 187);
            this.epochsLabel.Name = "epochsLabel";
            this.epochsLabel.Size = new System.Drawing.Size(46, 13);
            this.epochsLabel.TabIndex = 28;
            this.epochsLabel.Text = "Epochs:";
            // 
            // epochsInput
            // 
            this.epochsInput.Location = new System.Drawing.Point(191, 204);
            this.epochsInput.Name = "epochsInput";
            this.epochsInput.Size = new System.Drawing.Size(110, 20);
            this.epochsInput.TabIndex = 27;
            this.epochsInput.Text = "1";
            // 
            // saveNetworkButton
            // 
            this.saveNetworkButton.Location = new System.Drawing.Point(20, 234);
            this.saveNetworkButton.Name = "saveNetworkButton";
            this.saveNetworkButton.Size = new System.Drawing.Size(127, 27);
            this.saveNetworkButton.TabIndex = 29;
            this.saveNetworkButton.Text = "Save Network";
            this.saveNetworkButton.UseVisualStyleBackColor = true;
            this.saveNetworkButton.Click += new System.EventHandler(this.saveNetworkButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 27);
            this.button1.TabIndex = 30;
            this.button1.Text = "Test User Input";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(774, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 27);
            this.button2.TabIndex = 31;
            this.button2.Text = "Auto-Train";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Sample Size:";
            // 
            // sampleSizeTextBox
            // 
            this.sampleSizeTextBox.Location = new System.Drawing.Point(191, 247);
            this.sampleSizeTextBox.Name = "sampleSizeTextBox";
            this.sampleSizeTextBox.Size = new System.Drawing.Size(110, 20);
            this.sampleSizeTextBox.TabIndex = 32;
            this.sampleSizeTextBox.Text = "5000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(913, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sampleSizeTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveNetworkButton);
            this.Controls.Add(this.epochsLabel);
            this.Controls.Add(this.epochsInput);
            this.Controls.Add(this.loadTrainingDataButton);
            this.Controls.Add(this.inputLengthLabel);
            this.Controls.Add(this.inputLengthInput);
            this.Controls.Add(this.learnRateLabel);
            this.Controls.Add(this.learnRateInput);
            this.Controls.Add(this.netLayoutLabel);
            this.Controls.Add(this.netLayoutInput);
            this.Controls.Add(this.networkTestButton);
            this.Controls.Add(this.networkFilePathLabel);
            this.Controls.Add(this.networkFilePathInput);
            this.Controls.Add(this.mnistFullCheckbox);
            this.Controls.Add(this.chooseTrainingDataLabel);
            this.Controls.Add(this.trainNetworkButton);
            this.Controls.Add(this.mnistQuadCheckbox);
            this.Controls.Add(this.mnistBinCheckbox);
            this.Controls.Add(this.xorGateCheckbox);
            this.Controls.Add(this.andGateCheckbox);
            this.Controls.Add(this.loadNetworkButton);
            this.Controls.Add(this.newNetworkButton);
            this.Controls.Add(this.mnistDatasetInputLabel);
            this.Controls.Add(this.userInputLabel);
            this.Controls.Add(this.reloadTrainingImagesButton);
            this.Controls.Add(this.MNISTDatasetInputPictureBox);
            this.Controls.Add(this.background);
            this.Controls.Add(this.createNewNetworkBackground);
            this.Controls.Add(this.loadNetworkBackground);
            this.Controls.Add(this.trainNetworkBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Machine Learning App";
            ((System.ComponentModel.ISupportInitialize)(this.MNISTDatasetInputPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createNewNetworkBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadNetworkBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainNetworkBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel background;
        private System.Windows.Forms.PictureBox MNISTDatasetInputPictureBox;
        private System.Windows.Forms.Button reloadTrainingImagesButton;
        private System.Windows.Forms.Label userInputLabel;
        private System.Windows.Forms.Label mnistDatasetInputLabel;
        private System.Windows.Forms.Button newNetworkButton;
        private System.Windows.Forms.Button loadNetworkButton;
        private System.Windows.Forms.CheckBox andGateCheckbox;
        private System.Windows.Forms.CheckBox xorGateCheckbox;
        private System.Windows.Forms.CheckBox mnistBinCheckbox;
        private System.Windows.Forms.CheckBox mnistQuadCheckbox;
        private System.Windows.Forms.Button trainNetworkButton;
        private System.Windows.Forms.Label chooseTrainingDataLabel;
        private System.Windows.Forms.CheckBox mnistFullCheckbox;
        private System.Windows.Forms.TextBox networkFilePathInput;
        private System.Windows.Forms.Label networkFilePathLabel;
        private System.Windows.Forms.Button networkTestButton;
        private System.Windows.Forms.PictureBox createNewNetworkBackground;
        private System.Windows.Forms.PictureBox loadNetworkBackground;
        private System.Windows.Forms.TextBox netLayoutInput;
        private System.Windows.Forms.Label netLayoutLabel;
        private System.Windows.Forms.Label learnRateLabel;
        private System.Windows.Forms.TextBox learnRateInput;
        private System.Windows.Forms.Label inputLengthLabel;
        private System.Windows.Forms.TextBox inputLengthInput;
        private System.Windows.Forms.PictureBox trainNetworkBackground;
        private System.Windows.Forms.Button loadTrainingDataButton;
        private System.Windows.Forms.Label epochsLabel;
        private System.Windows.Forms.TextBox epochsInput;
        private System.Windows.Forms.Button saveNetworkButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sampleSizeTextBox;
    }
}


namespace Filipino_Flowers_Multilayer_Perceptron
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
            this.pictureBoxFlower = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.btnLoadDataset = new System.Windows.Forms.Button();
            this.btnTrainModel = new System.Windows.Forms.Button();
            this.txtTrainingLog = new System.Windows.Forms.TextBox();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.btnPredictFlower = new System.Windows.Forms.Button();
            this.lblPrediction = new System.Windows.Forms.Label();
            this.btnSaveTrainingLog = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlower)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFlower
            // 
            this.pictureBoxFlower.BackColor = System.Drawing.Color.White;
            this.pictureBoxFlower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFlower.Location = new System.Drawing.Point(122, 165);
            this.pictureBoxFlower.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxFlower.Name = "pictureBoxFlower";
            this.pictureBoxFlower.Size = new System.Drawing.Size(113, 117);
            this.pictureBoxFlower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFlower.TabIndex = 0;
            this.pictureBoxFlower.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(225)))), ((int)(((byte)(214)))));
            this.btnUploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadImage.Location = new System.Drawing.Point(112, 295);
            this.btnUploadImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(132, 34);
            this.btnUploadImage.TabIndex = 1;
            this.btnUploadImage.Text = "Upload Flower Image";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadDataset
            // 
            this.btnLoadDataset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.btnLoadDataset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDataset.Location = new System.Drawing.Point(11, 66);
            this.btnLoadDataset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadDataset.Name = "btnLoadDataset";
            this.btnLoadDataset.Size = new System.Drawing.Size(120, 34);
            this.btnLoadDataset.TabIndex = 2;
            this.btnLoadDataset.Text = "Load Dataset";
            this.btnLoadDataset.UseVisualStyleBackColor = true;
            this.btnLoadDataset.Click += new System.EventHandler(this.btnLoadDataset_Click);
            // 
            // btnTrainModel
            // 
            this.btnTrainModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(220)))), ((int)(((byte)(155)))));
            this.btnTrainModel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTrainModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainModel.Location = new System.Drawing.Point(138, 66);
            this.btnTrainModel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTrainModel.Name = "btnTrainModel";
            this.btnTrainModel.Size = new System.Drawing.Size(130, 34);
            this.btnTrainModel.TabIndex = 3;
            this.btnTrainModel.Text = "Train Neural Network";
            this.btnTrainModel.UseVisualStyleBackColor = true;
            this.btnTrainModel.Click += new System.EventHandler(this.btnTrainModel_Click);
            // 
            // txtTrainingLog
            // 
            this.txtTrainingLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(245)))));
            this.txtTrainingLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrainingLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtTrainingLog.Location = new System.Drawing.Point(364, 110);
            this.txtTrainingLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTrainingLog.Multiline = true;
            this.txtTrainingLog.Name = "txtTrainingLog";
            this.txtTrainingLog.ReadOnly = true;
            this.txtTrainingLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrainingLog.Size = new System.Drawing.Size(303, 270);
            this.txtTrainingLog.TabIndex = 4;
            this.txtTrainingLog.WordWrap = false;
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(229)))), ((int)(((byte)(245)))));
            this.btnLoadModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadModel.Location = new System.Drawing.Point(276, 66);
            this.btnLoadModel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(126, 34);
            this.btnLoadModel.TabIndex = 5;
            this.btnLoadModel.Text = "Load Trained Model";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // btnPredictFlower
            // 
            this.btnPredictFlower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.btnPredictFlower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPredictFlower.Location = new System.Drawing.Point(122, 346);
            this.btnPredictFlower.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPredictFlower.Name = "btnPredictFlower";
            this.btnPredictFlower.Size = new System.Drawing.Size(113, 34);
            this.btnPredictFlower.TabIndex = 6;
            this.btnPredictFlower.Text = "Predict Flower";
            this.btnPredictFlower.UseVisualStyleBackColor = true;
            this.btnPredictFlower.Click += new System.EventHandler(this.btnPredictFlower_Click);
            // 
            // lblPrediction
            // 
            this.lblPrediction.AutoSize = true;
            this.lblPrediction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrediction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.lblPrediction.Location = new System.Drawing.Point(69, 126);
            this.lblPrediction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrediction.Name = "lblPrediction";
            this.lblPrediction.Size = new System.Drawing.Size(236, 20);
            this.lblPrediction.TabIndex = 7;
            this.lblPrediction.Text = "Prediction: Not yet classified";
            // 
            // btnSaveTrainingLog
            // 
            this.btnSaveTrainingLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(218)))), ((int)(((byte)(239)))));
            this.btnSaveTrainingLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTrainingLog.Location = new System.Drawing.Point(406, 66);
            this.btnSaveTrainingLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveTrainingLog.Name = "btnSaveTrainingLog";
            this.btnSaveTrainingLog.Size = new System.Drawing.Size(110, 34);
            this.btnSaveTrainingLog.TabIndex = 8;
            this.btnSaveTrainingLog.Text = "Save Training Log";
            this.btnSaveTrainingLog.UseVisualStyleBackColor = true;
            this.btnSaveTrainingLog.Click += new System.EventHandler(this.btnSaveTrainingLog_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(54)))), ((int)(((byte)(68)))));
            this.lblTitle.Location = new System.Drawing.Point(10, 6);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(525, 32);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "✿ Filipino Flowers • Multilayer Perceptron ✿";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lblSubtitle.Location = new System.Drawing.Point(13, 38);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(406, 17);
            this.lblSubtitle.TabIndex = 10;
            this.lblSubtitle.Text = "Gumamela • Katuray • Banana Blossom • Squash Flower • Sunflower ";
            this.lblSubtitle.Click += new System.EventHandler(this.lblSubtitle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(692, 410);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSaveTrainingLog);
            this.Controls.Add(this.lblPrediction);
            this.Controls.Add(this.btnPredictFlower);
            this.Controls.Add(this.btnLoadModel);
            this.Controls.Add(this.txtTrainingLog);
            this.Controls.Add(this.btnTrainModel);
            this.Controls.Add(this.btnLoadDataset);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.pictureBoxFlower);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Filipino Flowers - Neural Network Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFlower;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnLoadDataset;
        private System.Windows.Forms.Button btnTrainModel;
        private System.Windows.Forms.TextBox txtTrainingLog;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Button btnPredictFlower;
        private System.Windows.Forms.Label lblPrediction;
        private System.Windows.Forms.Button btnSaveTrainingLog;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
    }
}


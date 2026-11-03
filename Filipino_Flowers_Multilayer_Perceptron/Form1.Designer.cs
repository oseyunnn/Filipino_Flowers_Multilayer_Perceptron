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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlower)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFlower
            // 
            this.pictureBoxFlower.Location = new System.Drawing.Point(245, 270);
            this.pictureBoxFlower.Name = "pictureBoxFlower";
            this.pictureBoxFlower.Size = new System.Drawing.Size(224, 224);
            this.pictureBoxFlower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFlower.TabIndex = 0;
            this.pictureBoxFlower.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.Location = new System.Drawing.Point(223, 525);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(263, 66);
            this.btnUploadImage.TabIndex = 1;
            this.btnUploadImage.Text = "Upload Flower Image";
            this.btnUploadImage.UseVisualStyleBackColor = true;
            this.btnUploadImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadDataset
            // 
            this.btnLoadDataset.Location = new System.Drawing.Point(21, 48);
            this.btnLoadDataset.Name = "btnLoadDataset";
            this.btnLoadDataset.Size = new System.Drawing.Size(241, 66);
            this.btnLoadDataset.TabIndex = 2;
            this.btnLoadDataset.Text = "Load Dataset";
            this.btnLoadDataset.UseVisualStyleBackColor = true;
            this.btnLoadDataset.Click += new System.EventHandler(this.btnLoadDataset_Click);
            // 
            // btnTrainModel
            // 
            this.btnTrainModel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTrainModel.Location = new System.Drawing.Point(276, 48);
            this.btnTrainModel.Name = "btnTrainModel";
            this.btnTrainModel.Size = new System.Drawing.Size(261, 66);
            this.btnTrainModel.TabIndex = 3;
            this.btnTrainModel.Text = "Train Neural Network";
            this.btnTrainModel.UseVisualStyleBackColor = true;
            this.btnTrainModel.Click += new System.EventHandler(this.btnTrainModel_Click);
            // 
            // txtTrainingLog
            // 
            this.txtTrainingLog.Location = new System.Drawing.Point(731, 161);
            this.txtTrainingLog.Multiline = true;
            this.txtTrainingLog.Name = "txtTrainingLog";
            this.txtTrainingLog.ReadOnly = true;
            this.txtTrainingLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrainingLog.Size = new System.Drawing.Size(604, 518);
            this.txtTrainingLog.TabIndex = 4;
            this.txtTrainingLog.WordWrap = false;
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Location = new System.Drawing.Point(552, 48);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(251, 66);
            this.btnLoadModel.TabIndex = 5;
            this.btnLoadModel.Text = "Load Trained Model";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // btnPredictFlower
            // 
            this.btnPredictFlower.Location = new System.Drawing.Point(245, 614);
            this.btnPredictFlower.Name = "btnPredictFlower";
            this.btnPredictFlower.Size = new System.Drawing.Size(226, 65);
            this.btnPredictFlower.TabIndex = 6;
            this.btnPredictFlower.Text = "Predict Flower";
            this.btnPredictFlower.UseVisualStyleBackColor = true;
            this.btnPredictFlower.Click += new System.EventHandler(this.btnPredictFlower_Click);
            // 
            // lblPrediction
            // 
            this.lblPrediction.AutoSize = true;
            this.lblPrediction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrediction.Location = new System.Drawing.Point(50, 161);
            this.lblPrediction.Name = "lblPrediction";
            this.lblPrediction.Size = new System.Drawing.Size(448, 37);
            this.lblPrediction.TabIndex = 7;
            this.lblPrediction.Text = "Prediction: Not yet classified";
            // 
            // btnSaveTrainingLog
            // 
            this.btnSaveTrainingLog.Location = new System.Drawing.Point(821, 48);
            this.btnSaveTrainingLog.Name = "btnSaveTrainingLog";
            this.btnSaveTrainingLog.Size = new System.Drawing.Size(220, 66);
            this.btnSaveTrainingLog.TabIndex = 8;
            this.btnSaveTrainingLog.Text = "Save Training Log";
            this.btnSaveTrainingLog.UseVisualStyleBackColor = true;
            this.btnSaveTrainingLog.Click += new System.EventHandler(this.btnSaveTrainingLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 789);
            this.Controls.Add(this.btnSaveTrainingLog);
            this.Controls.Add(this.lblPrediction);
            this.Controls.Add(this.btnPredictFlower);
            this.Controls.Add(this.btnLoadModel);
            this.Controls.Add(this.txtTrainingLog);
            this.Controls.Add(this.btnTrainModel);
            this.Controls.Add(this.btnLoadDataset);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.pictureBoxFlower);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}


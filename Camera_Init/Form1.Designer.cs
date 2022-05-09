
using System;

namespace Camera_Init
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.CameraFeedBack = new System.Windows.Forms.PictureBox();
            this.cboCamera = new System.Windows.Forms.ComboBox();
            this.FrameCapture = new System.Windows.Forms.Button();
            this.labelColorResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CameraFeedBack)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Detect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CameraFeedBack
            // 
            this.CameraFeedBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CameraFeedBack.Location = new System.Drawing.Point(12, 67);
            this.CameraFeedBack.MinimumSize = new System.Drawing.Size(600, 800);
            this.CameraFeedBack.Name = "CameraFeedBack";
            this.CameraFeedBack.Size = new System.Drawing.Size(649, 800);
            this.CameraFeedBack.TabIndex = 1;
            this.CameraFeedBack.TabStop = false;
            this.CameraFeedBack.Click += new System.EventHandler(this.CameraFeedBack_Click);
            // 
            // cboCamera
            // 
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(150, 23);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(273, 21);
            this.cboCamera.TabIndex = 2;
            // 
            // FrameCapture
            // 
            this.FrameCapture.Location = new System.Drawing.Point(473, 12);
            this.FrameCapture.Name = "FrameCapture";
            this.FrameCapture.Size = new System.Drawing.Size(106, 23);
            this.FrameCapture.TabIndex = 3;
            this.FrameCapture.Text = "Frame Capture";
            this.FrameCapture.UseVisualStyleBackColor = true;
            this.FrameCapture.Click += new System.EventHandler(this.FrameCapture_Click);
            // 
            // labelColorResult
            // 
            this.labelColorResult.AutoSize = true;
            this.labelColorResult.Location = new System.Drawing.Point(470, 38);
            this.labelColorResult.Name = "labelColorResult";
            this.labelColorResult.Size = new System.Drawing.Size(32, 13);
            this.labelColorResult.TabIndex = 4;
            this.labelColorResult.Text = "result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(657, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelColorResult);
            this.Controls.Add(this.FrameCapture);
            this.Controls.Add(this.cboCamera);
            this.Controls.Add(this.CameraFeedBack);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Gant LSF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.CameraFeedBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CameraFeedBack_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox CameraFeedBack;
        private System.Windows.Forms.ComboBox cboCamera;
        private System.Windows.Forms.Button FrameCapture;
        private System.Windows.Forms.Label labelColorResult;
        private System.Windows.Forms.Label label1;
    }
}


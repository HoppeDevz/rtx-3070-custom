namespace rtx_display
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gpuUsageLabel = new System.Windows.Forms.Label();
            this.gpuTempLabel = new System.Windows.Forms.Label();
            this.threadIndicatorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(25, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(526, 37);
            this.title.TabIndex = 0;
            this.title.Text = "RTX 3070 CUSTOM - PROVIDER";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::rtx_display.Properties.Resources.FhpI66AXwAAd4_j;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(32, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 355);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // gpuUsageLabel
            // 
            this.gpuUsageLabel.AutoSize = true;
            this.gpuUsageLabel.Location = new System.Drawing.Point(470, 88);
            this.gpuUsageLabel.Name = "gpuUsageLabel";
            this.gpuUsageLabel.Size = new System.Drawing.Size(110, 20);
            this.gpuUsageLabel.TabIndex = 2;
            this.gpuUsageLabel.Text = "GPU USAGE:";
            // 
            // gpuTempLabel
            // 
            this.gpuTempLabel.AutoSize = true;
            this.gpuTempLabel.Location = new System.Drawing.Point(470, 121);
            this.gpuTempLabel.Name = "gpuTempLabel";
            this.gpuTempLabel.Size = new System.Drawing.Size(173, 20);
            this.gpuTempLabel.TabIndex = 3;
            this.gpuTempLabel.Text = "GPU TEMPERATURE:";
            // 
            // threadIndicatorLabel
            // 
            this.threadIndicatorLabel.AutoSize = true;
            this.threadIndicatorLabel.Location = new System.Drawing.Point(474, 422);
            this.threadIndicatorLabel.Name = "threadIndicatorLabel";
            this.threadIndicatorLabel.Size = new System.Drawing.Size(189, 20);
            this.threadIndicatorLabel.TabIndex = 4;
            this.threadIndicatorLabel.Text = "{{THREAD-INDICATOR}}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 499);
            this.Controls.Add(this.threadIndicatorLabel);
            this.Controls.Add(this.gpuTempLabel);
            this.Controls.Add(this.gpuUsageLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.title);
            this.Name = "Form1";
            this.Text = "RTX 3070 CUSTOM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label gpuUsageLabel;
        private System.Windows.Forms.Label gpuTempLabel;
        private System.Windows.Forms.Label threadIndicatorLabel;
    }
}


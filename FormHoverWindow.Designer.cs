namespace aionHUD
{
    partial class FormHoverWindow
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
            this.labelLastUpdate = new System.Windows.Forms.Label();
            this.labelNPCSellPrice = new System.Windows.Forms.Label();
            this.labelMarketPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLastUpdate
            // 
            this.labelLastUpdate.AutoSize = true;
            this.labelLastUpdate.BackColor = System.Drawing.Color.Transparent;
            this.labelLastUpdate.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLastUpdate.ForeColor = System.Drawing.Color.White;
            this.labelLastUpdate.Location = new System.Drawing.Point(147, 53);
            this.labelLastUpdate.Name = "labelLastUpdate";
            this.labelLastUpdate.Size = new System.Drawing.Size(0, 22);
            this.labelLastUpdate.TabIndex = 40;
            // 
            // labelNPCSellPrice
            // 
            this.labelNPCSellPrice.AutoSize = true;
            this.labelNPCSellPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelNPCSellPrice.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNPCSellPrice.ForeColor = System.Drawing.Color.White;
            this.labelNPCSellPrice.Location = new System.Drawing.Point(147, 30);
            this.labelNPCSellPrice.Name = "labelNPCSellPrice";
            this.labelNPCSellPrice.Size = new System.Drawing.Size(0, 22);
            this.labelNPCSellPrice.TabIndex = 39;
            // 
            // labelMarketPrice
            // 
            this.labelMarketPrice.AutoSize = true;
            this.labelMarketPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelMarketPrice.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMarketPrice.ForeColor = System.Drawing.Color.White;
            this.labelMarketPrice.Location = new System.Drawing.Point(147, 7);
            this.labelMarketPrice.Name = "labelMarketPrice";
            this.labelMarketPrice.Size = new System.Drawing.Size(0, 22);
            this.labelMarketPrice.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 37;
            this.label2.Text = "Last update:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 22);
            this.label1.TabIndex = 36;
            this.label1.Text = "NPC sell price:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(23, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 22);
            this.label10.TabIndex = 35;
            this.label10.Text = "Broker price:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelLastUpdate);
            this.panel1.Controls.Add(this.labelNPCSellPrice);
            this.panel1.Controls.Add(this.labelMarketPrice);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 85);
            this.panel1.TabIndex = 41;
            // 
            // FormHoverWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(585, 110);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHoverWindow";
            this.Text = "FormHoverWindow";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.FormHoverWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label labelLastUpdate;
        public System.Windows.Forms.Label labelNPCSellPrice;
        public System.Windows.Forms.Label labelMarketPrice;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
    }
}
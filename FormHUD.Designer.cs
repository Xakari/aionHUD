namespace aionHUD
{
    partial class aionHUD
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aionHUD));
            this.panelMove = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBG = new System.Windows.Forms.Panel();
            this.labelCurrentRank = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTTRU = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.labelAPgained = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelEXPGained = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAPOverall = new System.Windows.Forms.Label();
            this.labelTimeToLevel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxHUDConsole = new System.Windows.Forms.TextBox();
            this.buttonResetAP = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.labelAPnH = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelEXPOverall = new System.Windows.Forms.Label();
            this.labelCurrentAP = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonResetExpCounter = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.labelEXPpH = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelEXP = new System.Windows.Forms.Label();
            this.aionHUDNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemBGColor = new System.Windows.Forms.ToolStripMenuItem();
            this.TranspToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemResize75 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemResize100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemresize110 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemResize125 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemResize150 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemResize175 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemResize200 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.panelMove.SuspendLayout();
            this.panelBG.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMove
            // 
            this.panelMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.panelMove.Controls.Add(this.label5);
            this.panelMove.Controls.Add(this.label1);
            this.panelMove.Location = new System.Drawing.Point(2, 0);
            this.panelMove.Name = "panelMove";
            this.panelMove.Size = new System.Drawing.Size(424, 23);
            this.panelMove.TabIndex = 34;
            this.panelMove.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMove_Paint);
            this.panelMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMove_MouseDown);
            this.panelMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMove_MouseMove);
            this.panelMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelMove_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(212, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Move";
            // 
            // panelBG
            // 
            this.panelBG.AutoSize = true;
            this.panelBG.BackColor = System.Drawing.Color.SlateGray;
            this.panelBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBG.Controls.Add(this.labelCurrentRank);
            this.panelBG.Controls.Add(this.panelMove);
            this.panelBG.Controls.Add(this.buttonClose);
            this.panelBG.Controls.Add(this.label3);
            this.panelBG.Controls.Add(this.labelTTRU);
            this.panelBG.Controls.Add(this.label);
            this.panelBG.Controls.Add(this.labelAPgained);
            this.panelBG.Controls.Add(this.label4);
            this.panelBG.Controls.Add(this.labelEXPGained);
            this.panelBG.Controls.Add(this.label2);
            this.panelBG.Controls.Add(this.labelAPOverall);
            this.panelBG.Controls.Add(this.labelTimeToLevel);
            this.panelBG.Controls.Add(this.label19);
            this.panelBG.Controls.Add(this.textBoxHUDConsole);
            this.panelBG.Controls.Add(this.buttonResetAP);
            this.panelBG.Controls.Add(this.label13);
            this.panelBG.Controls.Add(this.labelAPnH);
            this.panelBG.Controls.Add(this.label21);
            this.panelBG.Controls.Add(this.labelEXPOverall);
            this.panelBG.Controls.Add(this.labelCurrentAP);
            this.panelBG.Controls.Add(this.label15);
            this.panelBG.Controls.Add(this.label23);
            this.panelBG.Controls.Add(this.label14);
            this.panelBG.Controls.Add(this.buttonResetExpCounter);
            this.panelBG.Controls.Add(this.label10);
            this.panelBG.Controls.Add(this.labelEXPpH);
            this.panelBG.Controls.Add(this.label12);
            this.panelBG.Controls.Add(this.label11);
            this.panelBG.Controls.Add(this.labelEXP);
            this.panelBG.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panelBG.Location = new System.Drawing.Point(9, 12);
            this.panelBG.Name = "panelBG";
            this.panelBG.Size = new System.Drawing.Size(468, 442);
            this.panelBG.TabIndex = 33;
            // 
            // labelCurrentRank
            // 
            this.labelCurrentRank.AutoSize = true;
            this.labelCurrentRank.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentRank.ForeColor = System.Drawing.Color.White;
            this.labelCurrentRank.Location = new System.Drawing.Point(64, 41);
            this.labelCurrentRank.Name = "labelCurrentRank";
            this.labelCurrentRank.Size = new System.Drawing.Size(58, 16);
            this.labelCurrentRank.TabIndex = 39;
            this.labelCurrentRank.Text = "No Rank";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(429, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(34, 23);
            this.buttonClose.TabIndex = 38;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Rank:";
            // 
            // labelTTRU
            // 
            this.labelTTRU.AutoSize = true;
            this.labelTTRU.BackColor = System.Drawing.Color.Transparent;
            this.labelTTRU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTTRU.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTTRU.ForeColor = System.Drawing.Color.White;
            this.labelTTRU.Location = new System.Drawing.Point(360, 172);
            this.labelTTRU.Name = "labelTTRU";
            this.labelTTRU.Size = new System.Drawing.Size(15, 16);
            this.labelTTRU.TabIndex = 37;
            this.labelTTRU.Text = "0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(252, 172);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(102, 16);
            this.label.TabIndex = 36;
            this.label.Text = "Time to rank up:";
            // 
            // labelAPgained
            // 
            this.labelAPgained.AutoSize = true;
            this.labelAPgained.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAPgained.ForeColor = System.Drawing.Color.White;
            this.labelAPgained.Location = new System.Drawing.Point(360, 112);
            this.labelAPgained.Name = "labelAPgained";
            this.labelAPgained.Size = new System.Drawing.Size(15, 16);
            this.labelAPgained.TabIndex = 35;
            this.labelAPgained.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(252, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "AP gained:";
            // 
            // labelEXPGained
            // 
            this.labelEXPGained.AutoSize = true;
            this.labelEXPGained.BackColor = System.Drawing.Color.Transparent;
            this.labelEXPGained.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEXPGained.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEXPGained.ForeColor = System.Drawing.Color.White;
            this.labelEXPGained.Location = new System.Drawing.Point(99, 112);
            this.labelEXPGained.Name = "labelEXPGained";
            this.labelEXPGained.Size = new System.Drawing.Size(15, 16);
            this.labelEXPGained.TabIndex = 33;
            this.labelEXPGained.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "EXP gained:";
            // 
            // labelAPOverall
            // 
            this.labelAPOverall.AutoSize = true;
            this.labelAPOverall.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAPOverall.ForeColor = System.Drawing.Color.White;
            this.labelAPOverall.Location = new System.Drawing.Point(360, 132);
            this.labelAPOverall.Name = "labelAPOverall";
            this.labelAPOverall.Size = new System.Drawing.Size(15, 16);
            this.labelAPOverall.TabIndex = 6;
            this.labelAPOverall.Text = "0";
            // 
            // labelTimeToLevel
            // 
            this.labelTimeToLevel.AutoSize = true;
            this.labelTimeToLevel.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeToLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTimeToLevel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTimeToLevel.ForeColor = System.Drawing.Color.White;
            this.labelTimeToLevel.Location = new System.Drawing.Point(99, 172);
            this.labelTimeToLevel.Name = "labelTimeToLevel";
            this.labelTimeToLevel.Size = new System.Drawing.Size(15, 16);
            this.labelTimeToLevel.TabIndex = 8;
            this.labelTimeToLevel.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(252, 132);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 16);
            this.label19.TabIndex = 5;
            this.label19.Text = "AP overall:";
            // 
            // textBoxHUDConsole
            // 
            this.textBoxHUDConsole.BackColor = System.Drawing.Color.DarkGray;
            this.textBoxHUDConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxHUDConsole.CausesValidation = false;
            this.textBoxHUDConsole.Font = new System.Drawing.Font("Arial", 12F);
            this.textBoxHUDConsole.ForeColor = System.Drawing.Color.White;
            this.textBoxHUDConsole.Location = new System.Drawing.Point(2, 225);
            this.textBoxHUDConsole.Multiline = true;
            this.textBoxHUDConsole.Name = "textBoxHUDConsole";
            this.textBoxHUDConsole.ReadOnly = true;
            this.textBoxHUDConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHUDConsole.Size = new System.Drawing.Size(461, 212);
            this.textBoxHUDConsole.TabIndex = 31;
            // 
            // buttonResetAP
            // 
            this.buttonResetAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.buttonResetAP.FlatAppearance.BorderSize = 0;
            this.buttonResetAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetAP.Font = new System.Drawing.Font("Arial", 9.75F);
            this.buttonResetAP.ForeColor = System.Drawing.Color.White;
            this.buttonResetAP.Location = new System.Drawing.Point(255, 194);
            this.buttonResetAP.Name = "buttonResetAP";
            this.buttonResetAP.Size = new System.Drawing.Size(86, 29);
            this.buttonResetAP.TabIndex = 4;
            this.buttonResetAP.Text = "Reset";
            this.buttonResetAP.UseVisualStyleBackColor = false;
            this.buttonResetAP.Click += new System.EventHandler(this.buttonResetAP_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(9, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Time to level:";
            // 
            // labelAPnH
            // 
            this.labelAPnH.AutoSize = true;
            this.labelAPnH.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAPnH.ForeColor = System.Drawing.Color.White;
            this.labelAPnH.Location = new System.Drawing.Point(360, 152);
            this.labelAPnH.Name = "labelAPnH";
            this.labelAPnH.Size = new System.Drawing.Size(15, 16);
            this.labelAPnH.TabIndex = 3;
            this.labelAPnH.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(252, 152);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 16);
            this.label21.TabIndex = 2;
            this.label21.Text = "AP/H:";
            // 
            // labelEXPOverall
            // 
            this.labelEXPOverall.AutoSize = true;
            this.labelEXPOverall.BackColor = System.Drawing.Color.Transparent;
            this.labelEXPOverall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEXPOverall.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEXPOverall.ForeColor = System.Drawing.Color.White;
            this.labelEXPOverall.Location = new System.Drawing.Point(99, 132);
            this.labelEXPOverall.Name = "labelEXPOverall";
            this.labelEXPOverall.Size = new System.Drawing.Size(15, 16);
            this.labelEXPOverall.TabIndex = 6;
            this.labelEXPOverall.Text = "0";
            // 
            // labelCurrentAP
            // 
            this.labelCurrentAP.AutoSize = true;
            this.labelCurrentAP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentAP.ForeColor = System.Drawing.Color.White;
            this.labelCurrentAP.Location = new System.Drawing.Point(360, 92);
            this.labelCurrentAP.Name = "labelCurrentAP";
            this.labelCurrentAP.Size = new System.Drawing.Size(15, 16);
            this.labelCurrentAP.TabIndex = 1;
            this.labelCurrentAP.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(252, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "AP Counter";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(252, 92);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 16);
            this.label23.TabIndex = 0;
            this.label23.Text = "AP:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(9, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 16);
            this.label14.TabIndex = 5;
            this.label14.Text = "EXP overall:";
            // 
            // buttonResetExpCounter
            // 
            this.buttonResetExpCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.buttonResetExpCounter.FlatAppearance.BorderSize = 0;
            this.buttonResetExpCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetExpCounter.Font = new System.Drawing.Font("Arial", 9.75F);
            this.buttonResetExpCounter.ForeColor = System.Drawing.Color.White;
            this.buttonResetExpCounter.Location = new System.Drawing.Point(12, 194);
            this.buttonResetExpCounter.Name = "buttonResetExpCounter";
            this.buttonResetExpCounter.Size = new System.Drawing.Size(85, 28);
            this.buttonResetExpCounter.TabIndex = 4;
            this.buttonResetExpCounter.Text = "Reset";
            this.buttonResetExpCounter.UseVisualStyleBackColor = false;
            this.buttonResetExpCounter.Click += new System.EventHandler(this.buttonResetExpCounter_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(9, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "XP Counter";
            // 
            // labelEXPpH
            // 
            this.labelEXPpH.AutoSize = true;
            this.labelEXPpH.BackColor = System.Drawing.Color.Transparent;
            this.labelEXPpH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEXPpH.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEXPpH.ForeColor = System.Drawing.Color.White;
            this.labelEXPpH.Location = new System.Drawing.Point(99, 152);
            this.labelEXPpH.Name = "labelEXPpH";
            this.labelEXPpH.Size = new System.Drawing.Size(15, 16);
            this.labelEXPpH.TabIndex = 3;
            this.labelEXPpH.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(9, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "EXP/H:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(9, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "EXP:";
            // 
            // labelEXP
            // 
            this.labelEXP.AutoSize = true;
            this.labelEXP.BackColor = System.Drawing.Color.Transparent;
            this.labelEXP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEXP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEXP.ForeColor = System.Drawing.Color.White;
            this.labelEXP.Location = new System.Drawing.Point(99, 92);
            this.labelEXP.Name = "labelEXP";
            this.labelEXP.Size = new System.Drawing.Size(15, 16);
            this.labelEXP.TabIndex = 1;
            this.labelEXP.Text = "0";
            // 
            // aionHUDNotifyIcon
            // 
            this.aionHUDNotifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.aionHUDNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("aionHUDNotifyIcon.Icon")));
            this.aionHUDNotifyIcon.Text = "aionHUD";
            this.aionHUDNotifyIcon.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBGColor,
            this.resizeToolStripMenuItem,
            this.toolStripMenuItemClose});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 70);
            this.contextMenuStrip1.Text = "aionHUD";
            // 
            // toolStripMenuItemBGColor
            // 
            this.toolStripMenuItemBGColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TranspToolStripMenuItem,
            this.BlackToolStripMenuItem,
            this.whiteToolStripMenuItem});
            this.toolStripMenuItemBGColor.Name = "toolStripMenuItemBGColor";
            this.toolStripMenuItemBGColor.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItemBGColor.Text = "Background";

            // 
            // TranspToolStripMenuItem
            // 
            this.TranspToolStripMenuItem.Name = "TranspToolStripMenuItem";
            this.TranspToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.TranspToolStripMenuItem.Text = "Transparent";
            this.TranspToolStripMenuItem.Click += new System.EventHandler(this.yesToolStripMenuItem_Click);
            // 
            // BlackToolStripMenuItem
            // 
            this.BlackToolStripMenuItem.Name = "BlackToolStripMenuItem";
            this.BlackToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.BlackToolStripMenuItem.Text = "Black";
            this.BlackToolStripMenuItem.Click += new System.EventHandler(this.noToolStripMenuItem_Click);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.whiteToolStripMenuItem.Text = "White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemResize75,
            this.toolStripMenuItemResize100,
            this.toolStripMenuItemresize110,
            this.toolStripMenuItemResize125,
            this.toolStripMenuItemResize150,
            this.toolStripMenuItemResize175,
            this.toolStripMenuItemResize200});
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            // 
            // toolStripMenuItemResize75
            // 
            this.toolStripMenuItemResize75.Name = "toolStripMenuItemResize75";
            this.toolStripMenuItemResize75.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemResize75.Text = "75%";
            this.toolStripMenuItemResize75.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItemResize100
            // 
            this.toolStripMenuItemResize100.Name = "toolStripMenuItemResize100";
            this.toolStripMenuItemResize100.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemResize100.Text = "100%";
            this.toolStripMenuItemResize100.Click += new System.EventHandler(this.toolStripMenuItemResize100_Click);
            // 
            // toolStripMenuItemresize110
            // 
            this.toolStripMenuItemresize110.Name = "toolStripMenuItemresize110";
            this.toolStripMenuItemresize110.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemresize110.Text = "110%";
            this.toolStripMenuItemresize110.Click += new System.EventHandler(this.toolStripMenuItemresize110_Click);
            // 
            // toolStripMenuItemResize125
            // 
            this.toolStripMenuItemResize125.Name = "toolStripMenuItemResize125";
            this.toolStripMenuItemResize125.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemResize125.Text = "125%";
            this.toolStripMenuItemResize125.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItemResize150
            // 
            this.toolStripMenuItemResize150.Name = "toolStripMenuItemResize150";
            this.toolStripMenuItemResize150.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemResize150.Text = "150%";
            this.toolStripMenuItemResize150.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItemResize175
            // 
            this.toolStripMenuItemResize175.Name = "toolStripMenuItemResize175";
            this.toolStripMenuItemResize175.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemResize175.Text = "175%";
            this.toolStripMenuItemResize175.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItemResize200
            // 
            this.toolStripMenuItemResize200.Name = "toolStripMenuItemResize200";
            this.toolStripMenuItemResize200.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItemResize200.Text = "200%";
            this.toolStripMenuItemResize200.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItemClose.Text = "Close";
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "aionHUD.com";
            // 
            // aionHUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(489, 454);
            this.Controls.Add(this.panelBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "aionHUD";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.aionHUD_FormClosing);
            this.Load += new System.EventHandler(this.aionHUD_Load);
            this.panelMove.ResumeLayout(false);
            this.panelMove.PerformLayout();
            this.panelBG.ResumeLayout(false);
            this.panelBG.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMove;
        private System.Windows.Forms.Panel panelBG;
        public System.Windows.Forms.Label labelTTRU;
        private System.Windows.Forms.Label label;
        public System.Windows.Forms.Label labelAPgained;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label labelEXPGained;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label labelAPOverall;
        public System.Windows.Forms.Label labelTimeToLevel;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox textBoxHUDConsole;
        private System.Windows.Forms.Button buttonResetAP;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label labelAPnH;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label labelEXPOverall;
        public System.Windows.Forms.Label labelCurrentAP;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonResetExpCounter;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label labelEXPpH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label labelEXP;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentRank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon aionHUDNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResize100;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResize125;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResize150;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResize175;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResize200;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResize75;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemresize110;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBGColor;
        private System.Windows.Forms.ToolStripMenuItem TranspToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.Label label5;
    }
}


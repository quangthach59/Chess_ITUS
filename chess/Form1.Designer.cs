namespace chess
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mfFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mfOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPlayerSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCustomize = new System.Windows.Forms.ToolStripMenuItem();
            this.mfGame = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.mfHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRules = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.gbPlayer2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLocation2 = new System.Windows.Forms.Label();
            this.lbAge2 = new System.Windows.Forms.Label();
            this.lbName2 = new System.Windows.Forms.Label();
            this.gbPlayer1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbLocation1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbAge1 = new System.Windows.Forms.Label();
            this.lbName1 = new System.Windows.Forms.Label();
            this.lbTime2 = new System.Windows.Forms.Label();
            this.lbTime1 = new System.Windows.Forms.Label();
            this.lbHistory = new System.Windows.Forms.ListBox();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.lbScore2 = new System.Windows.Forms.Label();
            this.lbScore1 = new System.Windows.Forms.Label();
            this.btnUndo2 = new System.Windows.Forms.Button();
            this.btnRedo2 = new System.Windows.Forms.Button();
            this.pbClock = new System.Windows.Forms.PictureBox();
            this.pbDevil = new System.Windows.Forms.PictureBox();
            this.prgAdvantage = new System.Windows.Forms.ProgressBar();
            this.lbCalculate = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbPlayer2.SuspendLayout();
            this.gbPlayer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDevil)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mfFile,
            this.mfOptions,
            this.mfGame,
            this.mfHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1366, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mfFile
            // 
            this.mfFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewGame,
            this.btnLoadGame,
            this.btnSaveGame,
            this.btnExit});
            this.mfFile.Name = "mfFile";
            this.mfFile.Size = new System.Drawing.Size(37, 20);
            this.mfFile.Text = "File";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.btnNewGame.Size = new System.Drawing.Size(174, 22);
            this.btnNewGame.Text = "New game";
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.btnLoadGame.Size = new System.Drawing.Size(174, 22);
            this.btnLoadGame.Text = "Load game";
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSaveGame.Size = new System.Drawing.Size(174, 22);
            this.btnSaveGame.Text = "Save game";
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.btnExit.Size = new System.Drawing.Size(174, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // mfOptions
            // 
            this.mfOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPlayerSettings,
            this.btnCustomize});
            this.mfOptions.Name = "mfOptions";
            this.mfOptions.Size = new System.Drawing.Size(61, 20);
            this.mfOptions.Text = "Options";
            // 
            // btnPlayerSettings
            // 
            this.btnPlayerSettings.Name = "btnPlayerSettings";
            this.btnPlayerSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.btnPlayerSettings.Size = new System.Drawing.Size(199, 22);
            this.btnPlayerSettings.Text = "Player\'s settings";
            this.btnPlayerSettings.Click += new System.EventHandler(this.btnPlayerSettings_Click);
            // 
            // btnCustomize
            // 
            this.btnCustomize.Name = "btnCustomize";
            this.btnCustomize.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCustomize.Size = new System.Drawing.Size(199, 22);
            this.btnCustomize.Text = "Customize";
            this.btnCustomize.Click += new System.EventHandler(this.btnCustomize_Click);
            // 
            // mfGame
            // 
            this.mfGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.btnRedo});
            this.mfGame.Name = "mfGame";
            this.mfGame.Size = new System.Drawing.Size(50, 20);
            this.mfGame.Text = "Game";
            // 
            // btnUndo
            // 
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.btnUndo.Size = new System.Drawing.Size(144, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.btnRedo.Size = new System.Drawing.Size(144, 22);
            this.btnRedo.Text = "Redo";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // mfHelp
            // 
            this.mfHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRules,
            this.btnAbout});
            this.mfHelp.Name = "mfHelp";
            this.mfHelp.Size = new System.Drawing.Size(44, 20);
            this.mfHelp.Text = "Help";
            // 
            // btnRules
            // 
            this.btnRules.Name = "btnRules";
            this.btnRules.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.btnRules.Size = new System.Drawing.Size(153, 22);
            this.btnRules.Text = "Rules";
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click_1);
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.btnAbout.Size = new System.Drawing.Size(153, 22);
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // gbPlayer2
            // 
            this.gbPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.gbPlayer2.Controls.Add(this.label3);
            this.gbPlayer2.Controls.Add(this.label2);
            this.gbPlayer2.Controls.Add(this.label1);
            this.gbPlayer2.Controls.Add(this.lbLocation2);
            this.gbPlayer2.Controls.Add(this.lbAge2);
            this.gbPlayer2.Controls.Add(this.lbName2);
            this.gbPlayer2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPlayer2.ForeColor = System.Drawing.Color.Red;
            this.gbPlayer2.Location = new System.Drawing.Point(9, 93);
            this.gbPlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.gbPlayer2.Name = "gbPlayer2";
            this.gbPlayer2.Padding = new System.Windows.Forms.Padding(2);
            this.gbPlayer2.Size = new System.Drawing.Size(315, 275);
            this.gbPlayer2.TabIndex = 1;
            this.gbPlayer2.TabStop = false;
            this.gbPlayer2.Text = "Player 2:";
            this.gbPlayer2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Age:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            // 
            // lbLocation2
            // 
            this.lbLocation2.AutoSize = true;
            this.lbLocation2.Location = new System.Drawing.Point(70, 49);
            this.lbLocation2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLocation2.Name = "lbLocation2";
            this.lbLocation2.Size = new System.Drawing.Size(54, 17);
            this.lbLocation2.TabIndex = 2;
            this.lbLocation2.Text = "location";
            // 
            // lbAge2
            // 
            this.lbAge2.AutoSize = true;
            this.lbAge2.Location = new System.Drawing.Point(269, 20);
            this.lbAge2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAge2.Name = "lbAge2";
            this.lbAge2.Size = new System.Drawing.Size(30, 17);
            this.lbAge2.TabIndex = 1;
            this.lbAge2.Text = "age";
            // 
            // lbName2
            // 
            this.lbName2.AutoSize = true;
            this.lbName2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName2.Location = new System.Drawing.Point(56, 20);
            this.lbName2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbName2.Name = "lbName2";
            this.lbName2.Size = new System.Drawing.Size(40, 17);
            this.lbName2.TabIndex = 0;
            this.lbName2.Text = "name";
            // 
            // gbPlayer1
            // 
            this.gbPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.gbPlayer1.Controls.Add(this.label4);
            this.gbPlayer1.Controls.Add(this.label5);
            this.gbPlayer1.Controls.Add(this.lbLocation1);
            this.gbPlayer1.Controls.Add(this.label6);
            this.gbPlayer1.Controls.Add(this.lbAge1);
            this.gbPlayer1.Controls.Add(this.lbName1);
            this.gbPlayer1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPlayer1.ForeColor = System.Drawing.Color.Blue;
            this.gbPlayer1.Location = new System.Drawing.Point(9, 426);
            this.gbPlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.gbPlayer1.Name = "gbPlayer1";
            this.gbPlayer1.Padding = new System.Windows.Forms.Padding(2);
            this.gbPlayer1.Size = new System.Drawing.Size(315, 275);
            this.gbPlayer1.TabIndex = 2;
            this.gbPlayer1.TabStop = false;
            this.gbPlayer1.Text = "Player 1:";
            this.gbPlayer1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Age:";
            // 
            // lbLocation1
            // 
            this.lbLocation1.AutoSize = true;
            this.lbLocation1.Location = new System.Drawing.Point(70, 49);
            this.lbLocation1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLocation1.Name = "lbLocation1";
            this.lbLocation1.Size = new System.Drawing.Size(54, 17);
            this.lbLocation1.TabIndex = 3;
            this.lbLocation1.Text = "location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name:";
            // 
            // lbAge1
            // 
            this.lbAge1.AutoSize = true;
            this.lbAge1.Location = new System.Drawing.Point(269, 20);
            this.lbAge1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAge1.Name = "lbAge1";
            this.lbAge1.Size = new System.Drawing.Size(30, 17);
            this.lbAge1.TabIndex = 2;
            this.lbAge1.Text = "age";
            // 
            // lbName1
            // 
            this.lbName1.AutoSize = true;
            this.lbName1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName1.Location = new System.Drawing.Point(56, 20);
            this.lbName1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbName1.Name = "lbName1";
            this.lbName1.Size = new System.Drawing.Size(40, 17);
            this.lbName1.TabIndex = 1;
            this.lbName1.Text = "name";
            // 
            // lbTime2
            // 
            this.lbTime2.AutoSize = true;
            this.lbTime2.BackColor = System.Drawing.Color.Transparent;
            this.lbTime2.Font = new System.Drawing.Font("Segoe UI", 38.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime2.ForeColor = System.Drawing.Color.Red;
            this.lbTime2.Location = new System.Drawing.Point(437, 24);
            this.lbTime2.Name = "lbTime2";
            this.lbTime2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbTime2.Size = new System.Drawing.Size(150, 68);
            this.lbTime2.TabIndex = 3;
            this.lbTime2.Text = "NULL";
            this.lbTime2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbTime2.Visible = false;
            // 
            // lbTime1
            // 
            this.lbTime1.AutoSize = true;
            this.lbTime1.BackColor = System.Drawing.Color.Transparent;
            this.lbTime1.Font = new System.Drawing.Font("Segoe UI", 38.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime1.ForeColor = System.Drawing.Color.Blue;
            this.lbTime1.Location = new System.Drawing.Point(756, 24);
            this.lbTime1.Name = "lbTime1";
            this.lbTime1.Size = new System.Drawing.Size(150, 68);
            this.lbTime1.TabIndex = 4;
            this.lbTime1.Text = "NULL";
            this.lbTime1.Visible = false;
            // 
            // lbHistory
            // 
            this.lbHistory.BackColor = System.Drawing.SystemColors.Control;
            this.lbHistory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHistory.FormattingEnabled = true;
            this.lbHistory.ItemHeight = 21;
            this.lbHistory.Location = new System.Drawing.Point(989, 99);
            this.lbHistory.Name = "lbHistory";
            this.lbHistory.Size = new System.Drawing.Size(355, 529);
            this.lbHistory.TabIndex = 5;
            this.lbHistory.Visible = false;
            this.lbHistory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbHistory_DrawItem);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Timer2
            // 
            this.Timer2.Interval = 1000;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // lbScore2
            // 
            this.lbScore2.AutoSize = true;
            this.lbScore2.BackColor = System.Drawing.Color.Transparent;
            this.lbScore2.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore2.ForeColor = System.Drawing.Color.Red;
            this.lbScore2.Location = new System.Drawing.Point(33, 369);
            this.lbScore2.Name = "lbScore2";
            this.lbScore2.Size = new System.Drawing.Size(56, 65);
            this.lbScore2.TabIndex = 3;
            this.lbScore2.Text = "0";
            this.lbScore2.Visible = false;
            // 
            // lbScore1
            // 
            this.lbScore1.AutoSize = true;
            this.lbScore1.BackColor = System.Drawing.Color.Transparent;
            this.lbScore1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore1.ForeColor = System.Drawing.Color.Blue;
            this.lbScore1.Location = new System.Drawing.Point(243, 369);
            this.lbScore1.Name = "lbScore1";
            this.lbScore1.Size = new System.Drawing.Size(56, 65);
            this.lbScore1.TabIndex = 4;
            this.lbScore1.Text = "0";
            this.lbScore1.Visible = false;
            // 
            // btnUndo2
            // 
            this.btnUndo2.AutoSize = true;
            this.btnUndo2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo2.Location = new System.Drawing.Point(989, 632);
            this.btnUndo2.Name = "btnUndo2";
            this.btnUndo2.Size = new System.Drawing.Size(142, 47);
            this.btnUndo2.TabIndex = 6;
            this.btnUndo2.Text = "<< Undo";
            this.btnUndo2.UseVisualStyleBackColor = true;
            this.btnUndo2.Visible = false;
            this.btnUndo2.Click += new System.EventHandler(this.btnUndo2_Click);
            // 
            // btnRedo2
            // 
            this.btnRedo2.AutoSize = true;
            this.btnRedo2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedo2.Location = new System.Drawing.Point(1206, 632);
            this.btnRedo2.Name = "btnRedo2";
            this.btnRedo2.Size = new System.Drawing.Size(138, 47);
            this.btnRedo2.TabIndex = 7;
            this.btnRedo2.Text = "Redo >>";
            this.btnRedo2.UseVisualStyleBackColor = true;
            this.btnRedo2.Visible = false;
            this.btnRedo2.Click += new System.EventHandler(this.btnRedo2_Click);
            // 
            // pbClock
            // 
            this.pbClock.Location = new System.Drawing.Point(628, 12);
            this.pbClock.Name = "pbClock";
            this.pbClock.Size = new System.Drawing.Size(80, 80);
            this.pbClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClock.TabIndex = 8;
            this.pbClock.TabStop = false;
            this.pbClock.Visible = false;
            // 
            // pbDevil
            // 
            this.pbDevil.Location = new System.Drawing.Point(912, 12);
            this.pbDevil.Name = "pbDevil";
            this.pbDevil.Size = new System.Drawing.Size(80, 80);
            this.pbDevil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDevil.TabIndex = 9;
            this.pbDevil.TabStop = false;
            this.pbDevil.Visible = false;
            // 
            // prgAdvantage
            // 
            this.prgAdvantage.Location = new System.Drawing.Point(9, 57);
            this.prgAdvantage.MarqueeAnimationSpeed = 1000;
            this.prgAdvantage.Name = "prgAdvantage";
            this.prgAdvantage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.prgAdvantage.RightToLeftLayout = true;
            this.prgAdvantage.Size = new System.Drawing.Size(315, 17);
            this.prgAdvantage.Step = 1;
            this.prgAdvantage.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgAdvantage.TabIndex = 10;
            this.prgAdvantage.Value = 50;
            this.prgAdvantage.Visible = false;
            // 
            // lbCalculate
            // 
            this.lbCalculate.AutoSize = true;
            this.lbCalculate.BackColor = System.Drawing.Color.Transparent;
            this.lbCalculate.Location = new System.Drawing.Point(78, 74);
            this.lbCalculate.Name = "lbCalculate";
            this.lbCalculate.Size = new System.Drawing.Size(173, 17);
            this.lbCalculate.TabIndex = 11;
            this.lbCalculate.Text = "Calcucale advantage (demo)";
            this.lbCalculate.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1366, 691);
            this.Controls.Add(this.pbDevil);
            this.Controls.Add(this.pbClock);
            this.Controls.Add(this.gbPlayer1);
            this.Controls.Add(this.btnRedo2);
            this.Controls.Add(this.btnUndo2);
            this.Controls.Add(this.lbScore1);
            this.Controls.Add(this.lbScore2);
            this.Controls.Add(this.lbHistory);
            this.Controls.Add(this.lbTime1);
            this.Controls.Add(this.lbTime2);
            this.Controls.Add(this.gbPlayer2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lbCalculate);
            this.Controls.Add(this.prgAdvantage);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess ITUS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbPlayer2.ResumeLayout(false);
            this.gbPlayer2.PerformLayout();
            this.gbPlayer1.ResumeLayout(false);
            this.gbPlayer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbClock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDevil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mfFile;
		private System.Windows.Forms.ToolStripMenuItem btnNewGame;
		private System.Windows.Forms.ToolStripMenuItem btnLoadGame;
		private System.Windows.Forms.ToolStripMenuItem btnSaveGame;
		private System.Windows.Forms.ToolStripMenuItem btnExit;
		private System.Windows.Forms.ToolStripMenuItem mfOptions;
		private System.Windows.Forms.ToolStripMenuItem btnPlayerSettings;
		private System.Windows.Forms.ToolStripMenuItem mfGame;
		private System.Windows.Forms.ToolStripMenuItem btnUndo;
		private System.Windows.Forms.ToolStripMenuItem btnRedo;
		private System.Windows.Forms.ToolStripMenuItem mfHelp;
		private System.Windows.Forms.ToolStripMenuItem btnRules;
		private System.Windows.Forms.ToolStripMenuItem btnAbout;
        public System.Windows.Forms.Label lbTime2;
        public System.Windows.Forms.Label lbLocation2;
        public System.Windows.Forms.Label lbAge2;
        public System.Windows.Forms.Label lbName2;
        public System.Windows.Forms.Label lbLocation1;
        public System.Windows.Forms.Label lbAge1;
        public System.Windows.Forms.Label lbName1;
        public System.Windows.Forms.Label lbTime1;
		public System.Windows.Forms.Timer Timer1;
		public System.Windows.Forms.Timer Timer2;
		public System.Windows.Forms.Label lbScore2;
		public System.Windows.Forms.Label lbScore1;
        public System.Windows.Forms.ListBox lbHistory;
        private System.Windows.Forms.Button btnUndo2;
        private System.Windows.Forms.Button btnRedo2;
        private System.Windows.Forms.ToolStripMenuItem btnCustomize;
        public System.Windows.Forms.GroupBox gbPlayer2;
        public System.Windows.Forms.GroupBox gbPlayer1;
        private System.Windows.Forms.PictureBox pbClock;
        public System.Windows.Forms.PictureBox pbDevil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ProgressBar prgAdvantage;
        private System.Windows.Forms.Label lbCalculate;
    }
}


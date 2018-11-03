namespace chess
{
    partial class frmNewGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpPlayer1 = new System.Windows.Forms.GroupBox();
            this.tbLocation1 = new System.Windows.Forms.TextBox();
            this.tbAge1 = new System.Windows.Forms.TextBox();
            this.tbName1 = new System.Windows.Forms.TextBox();
            this.grpPlayer2 = new System.Windows.Forms.GroupBox();
            this.tbLocation2 = new System.Windows.Forms.TextBox();
            this.tbAge2 = new System.Windows.Forms.TextBox();
            this.tbName2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTimeSelect = new System.Windows.Forms.ComboBox();
            this.grpPlayer1.SuspendLayout();
            this.grpPlayer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your info here:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Age:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Location:";
            // 
            // grpPlayer1
            // 
            this.grpPlayer1.Controls.Add(this.tbLocation1);
            this.grpPlayer1.Controls.Add(this.tbAge1);
            this.grpPlayer1.Controls.Add(this.tbName1);
            this.grpPlayer1.Controls.Add(this.label2);
            this.grpPlayer1.Controls.Add(this.label4);
            this.grpPlayer1.Controls.Add(this.label3);
            this.grpPlayer1.ForeColor = System.Drawing.Color.Blue;
            this.grpPlayer1.Location = new System.Drawing.Point(12, 35);
            this.grpPlayer1.Name = "grpPlayer1";
            this.grpPlayer1.Size = new System.Drawing.Size(364, 95);
            this.grpPlayer1.TabIndex = 4;
            this.grpPlayer1.TabStop = false;
            this.grpPlayer1.Text = "Player 1 (play as White)";
            // 
            // tbLocation1
            // 
            this.tbLocation1.Location = new System.Drawing.Point(201, 57);
            this.tbLocation1.Name = "tbLocation1";
            this.tbLocation1.Size = new System.Drawing.Size(157, 29);
            this.tbLocation1.TabIndex = 7;
            // 
            // tbAge1
            // 
            this.tbAge1.Location = new System.Drawing.Point(67, 57);
            this.tbAge1.MaxLength = 3;
            this.tbAge1.Name = "tbAge1";
            this.tbAge1.Size = new System.Drawing.Size(50, 29);
            this.tbAge1.TabIndex = 6;
            // 
            // tbName1
            // 
            this.tbName1.Location = new System.Drawing.Point(67, 22);
            this.tbName1.MaxLength = 35;
            this.tbName1.Name = "tbName1";
            this.tbName1.Size = new System.Drawing.Size(291, 29);
            this.tbName1.TabIndex = 5;
            // 
            // grpPlayer2
            // 
            this.grpPlayer2.Controls.Add(this.tbLocation2);
            this.grpPlayer2.Controls.Add(this.tbAge2);
            this.grpPlayer2.Controls.Add(this.tbName2);
            this.grpPlayer2.Controls.Add(this.label5);
            this.grpPlayer2.Controls.Add(this.label6);
            this.grpPlayer2.Controls.Add(this.label7);
            this.grpPlayer2.ForeColor = System.Drawing.Color.Red;
            this.grpPlayer2.Location = new System.Drawing.Point(12, 136);
            this.grpPlayer2.Name = "grpPlayer2";
            this.grpPlayer2.Size = new System.Drawing.Size(364, 95);
            this.grpPlayer2.TabIndex = 5;
            this.grpPlayer2.TabStop = false;
            this.grpPlayer2.Text = "Player 2 (play as Black)";
            // 
            // tbLocation2
            // 
            this.tbLocation2.Location = new System.Drawing.Point(201, 57);
            this.tbLocation2.Name = "tbLocation2";
            this.tbLocation2.Size = new System.Drawing.Size(157, 29);
            this.tbLocation2.TabIndex = 7;
            // 
            // tbAge2
            // 
            this.tbAge2.Location = new System.Drawing.Point(67, 57);
            this.tbAge2.MaxLength = 3;
            this.tbAge2.Name = "tbAge2";
            this.tbAge2.Size = new System.Drawing.Size(50, 29);
            this.tbAge2.TabIndex = 6;
            // 
            // tbName2
            // 
            this.tbName2.Location = new System.Drawing.Point(67, 22);
            this.tbName2.MaxLength = 35;
            this.tbName2.Name = "tbName2";
            this.tbName2.Size = new System.Drawing.Size(291, 29);
            this.tbName2.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Location:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Age:";
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(301, 237);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 31);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "Time: ";
            // 
            // cbTimeSelect
            // 
            this.cbTimeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeSelect.FormattingEnabled = true;
            this.cbTimeSelect.Items.AddRange(new object[] {
            "Blitz (3 minutes, +2 seconds)",
            "Rapid (5 minutes, +10 seconds)",
            "Standard (90 minutes, +30 seconds)"});
            this.cbTimeSelect.Location = new System.Drawing.Point(56, 237);
            this.cbTimeSelect.Name = "cbTimeSelect";
            this.cbTimeSelect.Size = new System.Drawing.Size(239, 29);
            this.cbTimeSelect.TabIndex = 8;
            this.cbTimeSelect.SelectedIndexChanged += new System.EventHandler(this.cbTimeSelect_SelectedIndexChanged);
            // 
            // frmNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 282);
            this.Controls.Add(this.cbTimeSelect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grpPlayer2);
            this.Controls.Add(this.grpPlayer1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewGame";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New game";
            this.grpPlayer1.ResumeLayout(false);
            this.grpPlayer1.PerformLayout();
            this.grpPlayer2.ResumeLayout(false);
            this.grpPlayer2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpPlayer1;
        private System.Windows.Forms.TextBox tbLocation1;
        private System.Windows.Forms.TextBox tbAge1;
        private System.Windows.Forms.TextBox tbName1;
        private System.Windows.Forms.GroupBox grpPlayer2;
        private System.Windows.Forms.TextBox tbLocation2;
        private System.Windows.Forms.TextBox tbAge2;
        private System.Windows.Forms.TextBox tbName2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTimeSelect;
    }
}
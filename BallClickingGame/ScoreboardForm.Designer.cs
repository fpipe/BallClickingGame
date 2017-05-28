namespace BallClickingGame
{
    partial class ScoreboardForm
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
            this.gbScores = new System.Windows.Forms.GroupBox();
            this.lbScores = new System.Windows.Forms.ListBox();
            this.lblScores = new System.Windows.Forms.Label();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbScores.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbScores
            // 
            this.gbScores.Controls.Add(this.btnViewAll);
            this.gbScores.Controls.Add(this.lblScores);
            this.gbScores.Controls.Add(this.lbScores);
            this.gbScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbScores.Location = new System.Drawing.Point(12, 12);
            this.gbScores.Name = "gbScores";
            this.gbScores.Size = new System.Drawing.Size(298, 375);
            this.gbScores.TabIndex = 0;
            this.gbScores.TabStop = false;
            this.gbScores.Text = "Scoreboard";
            // 
            // lbScores
            // 
            this.lbScores.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbScores.FormattingEnabled = true;
            this.lbScores.ItemHeight = 25;
            this.lbScores.Items.AddRange(new object[] {
            "999. Filip Pipe Simonovski  999",
            "2. Filip Simonovski 60",
            "3. Filip Simonovski 60",
            "4. Filip Simonovski 60",
            "5. Filip Simonovski 60",
            "6. Filip Simonovski 60",
            "7. Filip Simonovski 60",
            "8. Filip Simonovski 60",
            "9. Filip Simonovski 60",
            "10. Filip Simonovski 60",
            "11. Filip Simonovski 60"});
            this.lbScores.Location = new System.Drawing.Point(6, 58);
            this.lbScores.Name = "lbScores";
            this.lbScores.Size = new System.Drawing.Size(277, 275);
            this.lbScores.TabIndex = 0;
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScores.Location = new System.Drawing.Point(7, 30);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(280, 25);
            this.lblScores.TabIndex = 1;
            this.lblScores.Text = "Place      Player Name     Score";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewAll.Location = new System.Drawing.Point(96, 339);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(101, 29);
            this.btnViewAll.TabIndex = 2;
            this.btnViewAll.Text = "View All";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(121, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScoreboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 439);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbScores);
            this.Name = "ScoreboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scoreboard";
            this.gbScores.ResumeLayout(false);
            this.gbScores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbScores;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.ListBox lbScores;
        private System.Windows.Forms.Button button1;
    }
}
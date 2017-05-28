using BallClickingGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallClickingGame
{
    public partial class SaveScoreForm : Form
    {
        public Player Player { get; set; }
        public int Score;
        public string PlayerName;

        public SaveScoreForm()
        {
            InitializeComponent();
        }

        //Create the score form with score transferred
        public SaveScoreForm(int score) {
            InitializeComponent();
            this.Score = score;
            lblScore.Text = string.Format("Your score is: {0}", Score);
        }
        
        //Validate if the player name is longer than 3 characters and lower than 25
        private void tbPlayerName_Validating(object sender, CancelEventArgs e)
        {
            if (tbPlayerName.Text.Trim().Length < 3 || tbPlayerName.Text.Trim().Length > 25)
            {
                errorProviderPlayerName.SetError(tbPlayerName, "Please enter name with min 3 characters and max 25 characters");
                e.Cancel = true;
            }
            else {
                errorProviderPlayerName.SetError(tbPlayerName, null);
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Save button effect player is active in database,
        /// and will be visible in scoreboard
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            PlayerName = tbPlayerName.Text;
            Player = new Player(PlayerName, Score, true);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// Cancel button effect player is deactivated in database,
        /// and will not be visible in scoreboard
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            PlayerName = tbPlayerName.Text;
            Player = new Player(PlayerName, Score, false);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

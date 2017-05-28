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
    public partial class ScoreboardForm : Form
    {
        PlayersDoc PlayersDoc;
        public ScoreboardForm()
        {
            InitializeComponent();
        }

        public ScoreboardForm(PlayersDoc playersDoc)
        {
            InitializeComponent();
            PlayersDoc = playersDoc as PlayersDoc;
            FillScoreboardTop10();
        }

        //Fill the scoreboard with top10 players while initializing form
        public void FillScoreboardTop10()
        {
            lbScores.Items.Clear();
            List<Player> top10Players = PlayersDoc.getTop10Players();
            FillScoreboard(top10Players);
            if (top10Players.Count < 10) {
                btnViewAll.Visible = false;
            }
        }

        //Fill the scoreboard with top1000 players and diable the view all button
        public void FillScoreboardTop1000()
        {
            lbScores.Items.Clear();
            List<Player> top1000Players = PlayersDoc.getTop1000Players();
            FillScoreboard(top1000Players);
            btnViewAll.Visible = false;
        }

        //fill the scoreboard with the given list of players
        public void FillScoreboard(List<Player> players) {
            string item;
            int i = 1;
            //lbScores.Items.Add(String.Format("{0} {1} {2}", "No.", "Player Name", "Score"));
            foreach (Player player in players)
            {
                item = String.Format("{0} {1}  ({2})", i + ".", player.getName(), player.getScore());
                lbScores.Items.Add(new String(item.ToCharArray()));
                i++;
            }
        }

        //view top 1000
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            FillScoreboardTop1000();
        }

        //close the form and put some informations in the form object(not needed now)
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

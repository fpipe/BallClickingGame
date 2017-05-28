using BallClickingGame.Models;
using BallClickingGame.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallClickingGame
{
    public partial class GameForm : Form
    {
        public enum Mode
        {
            STANDARD,
            FUN
        }

        public PlayerRepository playerRepository = new PlayerRepository();
        public BallScene ballScene;
        public PlayersDoc playersDoc;
        public Timer ballMovingTimer;
        public Timer timeCountdownTimer;
        public int time;
        public static int defaultTime = 30;
        private string FileName;
        public bool canTheGameStart;
        public Mode GameMode;


        public GameForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Enabled = true;
            playersDoc = new PlayersDoc();

            //intializing ball moving timer
            ballMovingTimer = new Timer();
            ballMovingTimer.Interval = 10;
            ballMovingTimer.Tick += new EventHandler(ballMovingTimer_Tick);

            //initializing countdown timer
            timeCountdownTimer = new Timer();
            timeCountdownTimer.Interval = 1000;
            timeCountdownTimer.Tick += new EventHandler(timeCountdownTimer_Tick);

            canTheGameStart = false;

        }

        //Counting the gaming time and checking is the time over
        private void timeCountdownTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = string.Format("Time left: {0}", time.ToString());
            time--;
            //if the time is over
            if (time == -1)
            {
                timeOver();
                ballMovingTimer.Stop();
                time = defaultTime;
            }
        }

        //The time is over, open score form to save player to the datatabase
        private void timeOver()
        {
            canTheGameStart = false;
            timeCountdownTimer.Stop();
            SaveScoreForm scoreForm = new SaveScoreForm(ballScene.getScore());
            if (scoreForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                playersDoc.Add(scoreForm.Player);
                saveDocument();
                toggleHomeButtons();
                //save player to database
                //playerRepository.Create(scoreForm.Player);
                scoreForm.Close();

            }


        }

        //Timer to move the balls on the scene
        private void ballMovingTimer_Tick(object sender, EventArgs e)
        {
            //move the ball around the scene
            ballScene.Move();
            Invalidate(true);
        }

        //Paint on the form, redraw it
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            if (canTheGameStart)
            {
                ballScene.FormResizes(Width, Height);
                ballScene.Draw(e.Graphics);
            }

            //var image = this.BackgroundImage;
            //e.Graphics.Clear(Color.White);
            //this.BackgroundImage = image;

        }

        //Update status bar 
        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            if (canTheGameStart)
            {
                tsPointsStatus.Text = ballScene.getScoreText();
            }

        }

        //Check if the ball is clicked and update score
        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (canTheGameStart)
            {
                ballScene.checkBallClicked(e.Location.X, e.Location.Y);
            }

        }

        //Save Players Document works like save as just for first save
        public void saveDocument()
        {
            if (FileName == null)
            {
                getMyDocumentsPath();
                FileName = getMyDocumentsPath();
            }

            //if (FileName == null)
            //{
            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.Filter = "Ball clicling game score document (*.bcsc) |*.bcsc";
            //    saveFileDialog.Title = "Enter your scoreboard location";
            //    saveFileDialog.FileName = FileName;
            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        FileName = saveFileDialog.FileName;
            //    }
            //}

            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, playersDoc);
                }
            }
        }

        //Get path for the My Documents folder
        private string getMyDocumentsPath()
        {
            string fileName = "save.bcsc";
            string path = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", fileName);
            return path;
        }

        //Open Players Document by location with dialog
        public void openDocument()
        {
            if (FileName == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Ball clicling game score document (*.bcsc) |*.bcsc";
                openFileDialog.Title = "Enter your scoreboard location";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = openFileDialog.FileName;
                    try
                    {
                        using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                        {
                            IFormatter formatter = new BinaryFormatter();
                            playersDoc = (PlayersDoc)formatter.Deserialize(fileStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not read file: " + FileName);
                        FileName = null;
                        return;
                    }
                    //Invalidate(true);
                }
            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    playersDoc = (PlayersDoc)formatter.Deserialize(fileStream);
                }
            }

        }

        //Application terminate
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Open scoreboard form
        private void btnScoreboard_Click(object sender, EventArgs e)
        {
            openDocument();
            ScoreboardForm scoreboardForm = new ScoreboardForm(playersDoc);
            if (scoreboardForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                scoreboardForm.Close();
            }
        }

        //Toggle buttons Enabled->Disabled && Disabled->Enabled
        public void toggleHomeButtons()
        {
            //negate the enabled values
            //btnExit.Enabled = !btnExit.Enabled;
            //btnScoreboard.Enabled = !btnScoreboard.Enabled;
            //btnFun.Enabled = !btnFun.Enabled;
            //btnStandard.Enabled = !btnStandard.Enabled;

            //negate the visibile values
            btnExit.Visible = !btnExit.Visible;
            btnScoreboard.Visible = !btnScoreboard.Visible;
            btnStandard.Visible = !btnStandard.Visible;
            lblTime.Visible = !lblTime.Visible;

        }

        //Standard mode clicked
        private void btnStandard_Click(object sender, EventArgs e)
        {

            //Create the standard ball scene and add one ball
            ballScene = new BallScene();
            ballScene.AddBall(Width, Height);

            //Activete/Deactivate the button
            toggleHomeButtons();

            //this shows can the game start
            canTheGameStart = true;

            //start the timers
            ballMovingTimer.Start();
            timeCountdownTimer.Start();


            //initialize default time
            time = defaultTime;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //if there is not open dialog
            //if (FileName == null)
            //{
            //    FileName = getMyDocumentsPath();
            //    if (!Directory.Exists(FileName))
            //    {
            //        saveDocument();
            //    }
            //    else {
            //        openDocument();
            //    }
            //}
            FileName = getMyDocumentsPath();
            try
            {
                openDocument();
            }
            catch (Exception ex) {
                saveDocument();
            }
            //playerRepository.Create(new Player("Filip", 100, true));
            //playersDoc.Players = playerRepository.GetAll();
        }
    }
}

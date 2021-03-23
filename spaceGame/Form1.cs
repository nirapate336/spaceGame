using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;


namespace spaceGame
{
    public partial class form1 : Form
    {

        List<int> obstacleYLeftList = new List<int>();
        List<int> obstacleLeftSpeed = new List<int>();
        List<int> obstacleXLeftList = new List<int>();

        List<int> obstacleYRightList = new List<int>();
        List<int> obstacleRightSpeed = new List<int>();
        List<int> obstacleXRightList = new List<int>();



        SoundPlayer obstacle = new SoundPlayer(Properties.Resources.collision);
        SoundPlayer point = new SoundPlayer(Properties.Resources.laser);
        SoundPlayer winner = new SoundPlayer(Properties.Resources.win);



        int obstacleHeightList = 2;
        int obstacleWidthList = 10;
        Random randGen = new Random();
        int randValue;


        bool wDown = false;
        bool sDown = false;
        bool upDown = false;
        bool downDown = false;

        int player1X = 200;
        int player1Y = 320;
        int heroHeight = 30;
        int heroWidth = 5;
        int heroSpeed = 5;
        int player2X = 300;
        int player2Y = 320;

        int oneScore;
        int twoScore;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen orangePen = new Pen(Color.Orange);
        Pen greenPen = new Pen(Color.LimeGreen);

        string gameState = "waiting";
        public form1()
        {
            InitializeComponent();
        }
        public void GameInitialize()

        {
            titleLabel.Text = "";

            subTitleLabel.Text = "";
            gameTimer.Enabled = true;
            gameState = "running";
            oneScore = 0;
            twoScore = 0;
            playerOneScoreLabel.Text = $"{oneScore}";
            playerTwoScoreLabel.Text = $"{twoScore}";
            winnerLabel.Text = "";


            obstacleXLeftList.Clear();
            obstacleXRightList.Clear();
            obstacleYLeftList.Clear();
            obstacleYRightList.Clear();

            obstacleLeftSpeed.Clear();
            obstacleRightSpeed.Clear();

            player1X = 200;
            player1Y = 320;
            player2X = 300;
            player2Y = 320;

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;

                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;

                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;

                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }

                    break;

            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;

                case Keys.Down:
                    downDown = false;
                    break;

                case Keys.W:
                    wDown = false;
                    break;

                case Keys.S:
                    sDown = false;
                    break;

                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;

                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }

                    break;
            }

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")

            {

                titleLabel.Text = "Space Race!";

                subTitleLabel.Text = "Press Space Bar to Start or Escape to Exit";

            }

            else if (gameState == "over")
            {
                playerOneScoreLabel.Text = "";
                playerTwoScoreLabel.Text = "";

                titleLabel.Text = "GAME OVER";
                subTitleLabel.Text = "Press Space Bar to Start or Escape to Exit";

                if (oneScore == 3)
                {
                    winnerLabel.Text = "PLAYER 1 WINS";
                }
                else if (twoScore == 3)
                {
                    winnerLabel.Text = "PLAYER 2 WINS";
                }
            }
            else if (gameState == "running")
            {
                //rock ship #2 design 
                e.Graphics.DrawLine(greenPen, player2X, player2Y, player2X, player2Y + 20);
                e.Graphics.DrawLine(greenPen, player2X + 5, player2Y, player2X + 5, player2Y + 20);
                e.Graphics.DrawLine(greenPen, player2X, player2Y, player2X + 5, player2Y);
                e.Graphics.DrawLine(greenPen, player2X, player2Y + 20, player2X + 5, player2Y + 20);
                e.Graphics.DrawLine(greenPen, player2X, player2Y + 20, player2X + 5, player2Y + 20);
                e.Graphics.DrawLine(greenPen, player2X, player2Y, player2X + 5 / 2, player2Y - 10);
                e.Graphics.DrawLine(greenPen, player2X + 5, player2Y, player2X + 5 / 2, player2Y - 10);
                e.Graphics.DrawLine(orangePen, player2X, player2Y+20, player2X - 2, player2Y +22);
                e.Graphics.DrawLine(orangePen, player2X+5, player2Y + 20, player2X + 7, player2Y + 22);
                e.Graphics.DrawLine(orangePen, player2X-2, player2Y + 22, player2X +7, player2Y + 22);
                // rocket ship#1 design 
                e.Graphics.DrawLine(greenPen, player1X, player1Y, player1X, player1Y + 20);
                e.Graphics.DrawLine(greenPen, player1X + 5, player1Y, player1X + 5, player1Y + 20);
                e.Graphics.DrawLine(greenPen, player1X, player1Y, player1X + 5, player1Y);
                e.Graphics.DrawLine(greenPen, player1X, player1Y + 20, player1X + 5, player1Y + 20);
                e.Graphics.DrawLine(greenPen, player1X, player1Y + 20, player1X + 5, player1Y + 20);
                e.Graphics.DrawLine(greenPen, player1X, player1Y, player1X + 5 / 2, player1Y - 10);
                e.Graphics.DrawLine(greenPen, player1X + 5, player1Y, player1X + 5 / 2, player1Y - 10);
                e.Graphics.DrawLine(orangePen, player1X, player1Y + 20, player1X - 2, player1Y + 22);
                e.Graphics.DrawLine(orangePen, player1X + 5, player1Y + 20, player1X + 7, player1Y + 22);
                e.Graphics.DrawLine(orangePen, player1X - 2, player1Y + 22, player1X + 7, player1Y + 22);


                for (int i = 0; i < obstacleYLeftList.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, obstacleXLeftList[i], obstacleYLeftList[i], obstacleWidthList, obstacleHeightList);
                }
                for (int n = 0; n < obstacleYRightList.Count; n++)
                {
                    e.Graphics.FillRectangle(whiteBrush, obstacleXRightList[n], obstacleYRightList[n], obstacleWidthList, obstacleHeightList);
                }
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {


            // move player 1 and 2 up and down and keep them on screen
            if (upDown == true && player2Y > 0)
            {
                player2Y -= heroSpeed;
            }

            if (downDown == true && player2Y < 330)
            {
                player2Y += heroSpeed;
            }

            if (wDown == true && player1Y > 0)
            {
                player1Y -= heroSpeed;
            }

            if (sDown == true && player1Y < 330)
            {
                player1Y += heroSpeed;
            }

            // check to see if we need to add asteroid
            randValue = randGen.Next(0, 101);
            if (randValue <= 7)
            {

                obstacleYLeftList.Add(randGen.Next(2, 300));
                obstacleLeftSpeed.Add(randGen.Next(2, 5));
                obstacleXLeftList.Add(0);

            }
            else if (randValue <= 15)
            {
                obstacleYRightList.Add(randGen.Next(2, 300));
                obstacleRightSpeed.Add(randGen.Next(2, 5));
                obstacleXRightList.Add(500);
            }

            //move asteriod by its given speed

            for (int i = 0; i < obstacleYLeftList.Count(); i++)
            {
                obstacleXLeftList[i] += obstacleLeftSpeed[i];
            }
            for (int i = 0; i < obstacleYRightList.Count(); i++)
            {
                obstacleXRightList[i] -= obstacleRightSpeed[i];
            }
            // give points if they reach the top of the game
            if (player1Y < 20)
            {
                oneScore++;
                playerOneScoreLabel.Text = $"{oneScore}";
                player1Y = 320;
                point.Play();

            }
            if (player2Y < 20)
            {
                twoScore++;
                playerTwoScoreLabel.Text = $"{twoScore}";
                player2Y = 320;
                point.Play();
            }


            //check for collisions between the asteriods and the play
            Rectangle player1Rec = new Rectangle(player1X, player1Y - 10, heroWidth, heroHeight);
            Rectangle player2Rec = new Rectangle(player2X, player2Y - 10, heroWidth, heroHeight);

            for (int i = 0; i < obstacleYLeftList.Count(); i++)
            {
                Rectangle obstacleLeftRec = new Rectangle(obstacleXLeftList[i], obstacleYLeftList[i], obstacleWidthList, obstacleHeightList);

                if (player1Rec.IntersectsWith(obstacleLeftRec))
                {
                    player1Y = 400 - heroHeight - heroHeight;
                    obstacle.Play();

                    break;
                }
                else if (player2Rec.IntersectsWith(obstacleLeftRec))
                {
                    obstacle.Play();
                    player2Y = 400 - heroHeight - heroHeight;
                    obstacle.Play();
                    break;
                }
            }

            for (int r = 0; r < obstacleYRightList.Count(); r++)
            {
                Rectangle obstacleRightRec = new Rectangle(obstacleXRightList[r], obstacleYRightList[r], obstacleWidthList, obstacleHeightList);
                if (player1Rec.IntersectsWith(obstacleRightRec))
                {
                    player1Y = 400 - heroHeight - heroHeight;
                    obstacle.Play();
                    break;
                }
                else if (player2Rec.IntersectsWith(obstacleRightRec))
                {
                    player2Y = 400 - heroHeight - heroHeight;
                    obstacle.Play();
                    break;
                }
            }

            if (oneScore == 3 || twoScore == 3)
            {
                winner.Play();
                gameTimer.Enabled = false;
                gameState = "over";
            }



            Refresh();

        }

    }
}

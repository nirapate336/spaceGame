using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceGame
{
    public partial class Form1 : Form
    {

        List<int> obstacleYLeftList = new List<int>();
        List<int> obstacleLeftSpeed = new List<int>();
        List<int> obstacleXLeftList = new List<int>();

        List<int> obstacleYRightList = new List<int>();
        List<int> obstacleRightSpeed = new List<int>();
        List<int> obstacleXRightList = new List<int>();










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
        int heroHeight = 20;
        int heroWidth = 5;
        int heroSpeed = 5;
        int player2X = 300;
        int player2Y = 320;

        int oneScore;
        int twoScore;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Pen whitePen = new Pen(Color.White);

        string gameState = "waiting";
        public Form1()
        {
            InitializeComponent();
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
            }

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, player1X, player1Y, heroWidth, heroHeight);
            e.Graphics.FillRectangle(whiteBrush, player2X, player2Y, heroWidth, heroHeight);

            for (int i = 0; i < obstacleYLeftList.Count(); i++)
            {


                e.Graphics.FillRectangle(whiteBrush, obstacleXLeftList[i], obstacleYLeftList[i], obstacleWidthList, obstacleHeightList);

            }
            for (int n = 0; n < obstacleYRightList.Count; n++)
            {
                e.Graphics.FillRectangle(whiteBrush, obstacleXRightList[n], obstacleYRightList[n], obstacleWidthList, obstacleHeightList);
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
            if (randValue <= 5)
            {

                obstacleYLeftList.Add(randGen.Next(2, 300));
                obstacleLeftSpeed.Add(randGen.Next(2, 5));
                obstacleXLeftList.Add(0);

            }
            else if (randValue <= 11)
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
            }
            if (player2Y < 20)
            {
                twoScore++;
                playerTwoScoreLabel.Text = $"{twoScore}";
                player2Y = 320;
            }


            //check for collisions between the asteriods and the play
            Rectangle player1Rec = new Rectangle(player1X, player1Y, heroWidth, heroHeight);
            Rectangle player2Rec = new Rectangle(player2X, player2Y, heroWidth, heroHeight);

            for (int i = 0; i < obstacleYLeftList.Count(); i++)
            {
                Rectangle obstacleLeftRec = new Rectangle(obstacleXLeftList[i], obstacleYLeftList[i], obstacleWidthList, obstacleHeightList);
               // Rectangle obstacleRightRec = new Rectangle(obstacleXRightList[i], obstacleYRightList[i], obstacleWidthList, obstacleHeightList);

                if (player1Rec.IntersectsWith(obstacleLeftRec))//|| player1Rec.IntersectsWith(obstacleRightRec))
                {
                    player1Y = 320;
                }
               else if (player2Rec.IntersectsWith(obstacleLeftRec)) //|| player2Rec.IntersectsWith(obstacleRightRec))
                {
                    player2Y = 320;
                }
               
                break;
            }
















            if (oneScore == 3 || twoScore == 3)
            {
                gameTimer.Enabled = false;

            }



            Refresh();

        }

    }
}

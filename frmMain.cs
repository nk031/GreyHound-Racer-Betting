using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyHound_Racer_Betting
{
    public partial class frmMain : Form
    {
        // Initialize all the punters in game
        Punter[] PuntersInGame = new Punter[3];

        // Initialize all the dogs in game 
        Dogs[] DogsInGame = new Dogs[4];

        public frmMain()
        {
            InitializeComponent();
            // add all dogs to track
            pbTrack.Controls.Add(pbDog1);
            pbTrack.Controls.Add(pbDog2);
            pbTrack.Controls.Add(pbDog3);
            pbTrack.Controls.Add(pbDog4);
            // set dogs background to transaparent
            pbDog1.BackColor = Color.Transparent;
            pbDog2.BackColor = Color.Transparent;
            pbDog3.BackColor = Color.Transparent;
            pbDog4.BackColor = Color.Transparent;
            // set panel backcolor for screen output
            panelScreen.BackColor = Color.FromArgb(90, Color.Black);
            // call mehtod for dog race
            InitDogs();
            // call method for Punters init
            InitPunkers();
            // clear all labels
            ClearAllLabels();

            // reset width and height of dogs picture boxe
            foreach (Dogs d in DogsInGame)
            {
                d.MyPictureBox.Width = 100;
                d.MyPictureBox.Height = 100;
            }

        }
        // method to change animation of dogs
        public void ChangeDogsImagesSource()
        {
            pbDog1.Image = Properties.Resources._1;
            pbDog2.Image = Properties.Resources._2;
            pbDog3.Image = Properties.Resources._3;
            pbDog4.Image = Properties.Resources._4;

        }
        public void InitPunkers()
        {
            //Initialize all the punters using Factory Class
            for (int i = 0; i < 3; i++)
            {
                PuntersInGame[i] = Factory.GetInstanceOfPunter(i);
            }

            //set the labels to the classes and update
            PuntersInGame[0].MyLabel = lblJimmay;
            PuntersInGame[0].MyRadioButton = rbJimmy;
            PuntersInGame[0].MyRadioButton.Text = PuntersInGame[0].Name + " -> $" + PuntersInGame[0].Cash;
            PuntersInGame[1].MyLabel = lblPanther;
            PuntersInGame[1].MyRadioButton = rbPanther;
            PuntersInGame[1].MyRadioButton.Text = PuntersInGame[1].Name + " -> $" + PuntersInGame[1].Cash;
            PuntersInGame[2].MyLabel = lblMonty;
            PuntersInGame[2].MyRadioButton = rbMonty;
            PuntersInGame[2].MyRadioButton.Text = PuntersInGame[2].Name + " -> $" + PuntersInGame[2].Cash;

        }
        // Clear all labels
        public void ClearAllLabels() 
        {
            lblJimmay.Text = "";
            lblMonty.Text = "";
            lblPanther.Text = "";
        }

        // Checks to see if the game is over
        public void CheckForGameOver() 
        {
            if (PuntersInGame[0].Cash <= 0 && PuntersInGame[1].Cash <= 0 && PuntersInGame[2].Cash <= 0)
            {
                MessageBox.Show("All of the Betters are out of money.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ClearAllLabels();
                ResetRace();
                
            }

        }
        // this method checks for out of cash punkers and update labels accordingly
        public void CheckOutOfCash() 
        {
            if (PuntersInGame[0].Cash <= 0)//Jimmy
            {
                lblJimmay.Text = "Jimmy is now Out of money.";
                rbJimmy.Enabled = false;
            }
            if (PuntersInGame[1].Cash <= 0)//Panther
            {
                lblPanther.Text = "Panther is now out of money.";
                rbPanther.Enabled = false;
            }
            if (PuntersInGame[2].Cash <= 0)//Monty
            {
                lblMonty.Text = "Moty is now out of money.";
                rbMonty.Enabled = false;
            }

        }
        // resets the bet cash of punkers if he is busted(out of money)
        public void ResetBetCash() 
        {
            if (PuntersInGame[0].Cash == 0)
            {
                PuntersInGame[0].MyBet.Amount = 0;
            }
            if (PuntersInGame[1].Cash == 0)
            {
                PuntersInGame[1].MyBet.Amount = 0;
            }
            if (PuntersInGame[2].Cash == 0)
            {
                PuntersInGame[2].MyBet.Amount = 0;
            }
        }

        // Instantiate all the dogs in game
        public void InitDogs() 
        {
            DogsInGame[0] = new Dogs { MyPictureBox = pbDog1, StartingPosition = pbDog1.Left, DogName = "#1", RaceTrackLength = pbTrack.Width - pbDog1.Width, RandomSpeed = new Random() };
            DogsInGame[1] = new Dogs { MyPictureBox = pbDog2, StartingPosition = pbDog2.Left, DogName = "#2", RaceTrackLength = pbTrack.Width - pbDog2.Width, RandomSpeed = DogsInGame[0].RandomSpeed };
            DogsInGame[2] = new Dogs { MyPictureBox = pbDog3, StartingPosition = pbDog3.Left, DogName = "#3", RaceTrackLength = pbTrack.Width - pbDog3.Width, RandomSpeed = DogsInGame[0].RandomSpeed };
            DogsInGame[3] = new Dogs { MyPictureBox = pbDog4, StartingPosition = pbDog4.Left, DogName = "#4", RaceTrackLength = pbTrack.Width - pbDog4.Width, RandomSpeed = DogsInGame[0].RandomSpeed };
        }
        // Reset race which also resets dogs position on track
        public void ResetRace() 
        {
            // Reset the label texts for punkers
            PuntersInGame[0].MyLabel.ResetText();
            PuntersInGame[1].MyLabel.ResetText();
            PuntersInGame[2].MyLabel.ResetText();
            //Reset the bet cash to zero
            PuntersInGame[0].MyBet.Amount = 0;
            PuntersInGame[1].MyBet.Amount = 0;
            PuntersInGame[2].MyBet.Amount = 0;
            // reet dog position and image
            foreach (Dogs t in DogsInGame)
            {
                t.MyPictureBox.Left = t.StartingPosition;
                ResetDogsImageSource();
            }

            
        }
        // this method change back to static image of dog
        public void ResetDogsImageSource()
        {
            pbDog1.Image = Properties.Resources.d1;
            pbDog2.Image = Properties.Resources.d2;
            pbDog3.Image = Properties.Resources.d3;
            pbDog4.Image = Properties.Resources.d4;
        }
        // bet button click event
        private void BtnBet_Click(object sender, EventArgs e)
        {
            int punter = 0;

            if (rbJimmy.Checked)
            {
                punter = 0;
            }
            else if (rbPanther.Checked)
            {
                punter = 1;
            }
            else if (rbMonty.Checked)
            {
                punter = 2;
            }

            // Updates the bet cash and Dog No using the Placebet method.
      
            PuntersInGame[punter].PlaceBet((int)nuBetAmount.Value, (int)nuDogNo.Value - 1); 
        }

        // race button click event
        private void BtnRace_Click(object sender, EventArgs e)
        {
            //Check to see if the punters have enough cash
            // give a warning if no cash
            if (PuntersInGame[0].Cash < nuBetAmount.Value && rbJimmy.Enabled)
            {
                MessageBox.Show("Jimmy does not have enough cash.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Enabled = false;
            }
            if (PuntersInGame[1].Cash < nuBetAmount.Value && rbPanther.Enabled)
            {
                MessageBox.Show("Panther does not have enough cash.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Enabled = false;
            }
            if (PuntersInGame[2].Cash < nuBetAmount.Value && rbMonty.Enabled)
            {
                MessageBox.Show("Monty does not have enough cash.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timer1.Enabled = false;
            }
            else
            {
                // all have enough cash and reset the positions in case
                //Reset starting positions
                foreach (Dogs t in DogsInGame)
                {
                    t.MyPictureBox.Left = t.StartingPosition;
                }

                // Start a timer for racing
                timer1.Enabled = true;
                // Disable the race button
                btnRace.Enabled = false; 
                // change animation
                ChangeDogsImagesSource();
            }

            if (PuntersInGame[0].Cash < PuntersInGame[0].MyBet.Amount)
            {
                MessageBox.Show("Jimmy does not have enough cash");
                btnRace.Enabled = false;
            }
            if (PuntersInGame[1].Cash < PuntersInGame[1].MyBet.Amount)
            {
                MessageBox.Show("Panther does not have enough cash");
                btnRace.Enabled = false;
            }
            if (PuntersInGame[2].Cash < PuntersInGame[2].MyBet.Amount)
            {
                MessageBox.Show("Monty does not have enough cash");
                btnRace.Enabled = false;
            }
            else
            {
                btnRace.Enabled = true;
            }

        }
        // race timer tick event
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int Winner;

                for (int i = 0; i < DogsInGame.Length; i++)
                {
                    if (DogsInGame[i].Run(pbTrack)) // use Dog.Run class for race and if true return a winner and stop timer event
                    {
                        Winner = i;
                        timer1.Enabled = false;
                        // if dogs reach end point reset image to static
                        ResetDogsImageSource();
                        // show a winner dog
                        MessageBox.Show("Dog #" + (Winner + 1) + " won the RACE!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // payout the cash according to the bet
                        for (int j = 0; j < PuntersInGame.Length; j++)
                        {
                            // check if payout cash is not zero
                            if (PuntersInGame[j].MyBet.PayOut(Winner) != 0)
                            {
                                // payout the cash to winner
                                    PuntersInGame[j].Cash += PuntersInGame[j].MyBet.PayOut(Winner); 
                            }
                            PuntersInGame[j].MyRadioButton.Text = PuntersInGame[j].Name + " -> $" + PuntersInGame[j].Cash; // Updates the radio button text with new cash value
                        }
                        // Resets race parameters
                        ResetRace();
                        // Reset bet cash
                        ResetBetCash();
                        // Checks to see if any one is busted and kick him out of bet
                        CheckOutOfCash();
                        // Check for gameover
                        // if all the bettes are busted
                        CheckForGameOver(); 
           
                        break;

                    }

                }
            }
            catch
            {
                MessageBox.Show("No Bet Placed. Please Bet on any dog to earn some cash.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
    }
}

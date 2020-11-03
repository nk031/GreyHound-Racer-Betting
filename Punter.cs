using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyHound_Racer_Betting
{
    public abstract class Punter
    {
        // name of the punter
        public string Name { get; set; }
        // object of the bet class
        public Bet MyBet { get; set; }
        // punter cash which is used for betting
        public int Cash { get; set; }
        // My selection for bet using radio button
        public RadioButton MyRadioButton { get; set; }
        // storing reference for Label
        public Label MyLabel { get; set; } 

        // method to update the bet description on buttons and labels
        public void UpdateLabels() 
        {
            MyLabel.Text = MyBet.GetDescription();
        }
        // method to place bet on a dog
        public bool PlaceBet(int BetCash, int winningDog) 
        {
            //Place a new bet and store it
            //return true if punter had enough money to bet
            if (Cash >= BetCash)
            {
                MyBet = new Bet()
                {
                    Amount = BetCash,
                    Dog = winningDog,
                    Bettor = this
                };

                UpdateLabels();

                return true;
            }
             else
            {
                // show message and return false in  case of no Cash
                MessageBox.Show(Name + " didn't have enough cash", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

        }

    }

    // INHERITANCE
    // INHERITANCE
    // INHERITANCE All betters will inherit from punter class
    // INHERITANCE
    public class Jimmy : Punter
    {
        public Jimmy() // ctor for punter Jimmy
        {
            Name = "Jimmy";
            Cash = 50;
        }

    }

    public class Monty : Punter 
    {
        public Monty() // ctor for Punter Monty
        {
            Name = "Monty";
            Cash = 50;
        }
    }

    public class Panther : Punter 
    {
        public Panther() // ctor for punter Panther
        {
            Name = "Panther";
            Cash = 50;
        }
    }
}


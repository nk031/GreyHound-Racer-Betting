using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound_Racer_Betting
{
    public class Bet
    {
        public int Amount { get; set; } // The amount of cash  
        public int Dog { get; set; } // The number of the Dog
        public Punter Bettor { get; set; } // The better who is placing a bet

        public string GetDescription() // return description of bet with amount, dog and better name
        {
            string description = Bettor.Name + " bet $" + Amount + " on Dog " + (Dog + 1);

            return description;
           
        }

        public int PayOut(int Winner) // payout to winner the amount of bet other wise returns a negative amount usng winner parameter 
        {
            if (Winner == Dog)
            {
                return Amount;
            }
            else
            {
                return  Amount*-1;
            }

        }
    }
}

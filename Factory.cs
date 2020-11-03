using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound_Racer_Betting
{
    public static class Factory
    {
        // Decides which class to instantiate
        public static Punter GetInstanceOfPunter(int id)
        {
            switch (id)
            {
                case 0: return new Jimmy();
                case 1: return new Panther();
                case 2: return new Monty();
                default: return null;
            }
        }
    }
}

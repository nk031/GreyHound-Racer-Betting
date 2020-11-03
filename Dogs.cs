using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreyHound_Racer_Betting
{
    class Dogs
    {
        // Dog name
        public string DogName { get; set; }

        // Starting position of dog picturebox
        public int StartingPosition { get; set; }
        // actual length of race track
        public int RaceTrackLength { get; set; } 
        public PictureBox MyPictureBox { get; set; } = null; // reference to dog picturebox
        // location on the track
        public int Location { get; set; } = 0;
        // random class object to generate random speed of dogs
        public Random RandomSpeed { get; set; } 

        public bool Run(PictureBox raceTrack)
        {
            // change speed between 0-6 randomly
            MyPictureBox.Left += RandomSpeed.Next(0, 6);

            // check for winner using bounds of pictureboxes
            if (MyPictureBox.Right > raceTrack.Right-(MyPictureBox.Width/2+1))
            {
                return true;// return there is a winner
            }

            return false;
        }
    }
}

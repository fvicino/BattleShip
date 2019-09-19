using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Abstraction
{
    public delegate void ShotLandedHandler(object sender, ShotEventArgs e);

    public class ShotEventArgs : EventArgs
    {
        public ShotEventArgs(int id, Point location)
        {
            Location = location;
        }
        public Point Location { get; }
    }
}

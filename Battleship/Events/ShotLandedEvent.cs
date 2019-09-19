using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Events
{
    public delegate void ShotLandedHandler(object sender, ShotEventArgs e);

    public class ShotEventArgs : EventArgs
    {
        public ShotEventArgs(int id, Point location)
        {
            Location = location;
            Id = id;
        }
        public Point Location { get; }
        public int Id { get; }
    }
}

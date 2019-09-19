using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace Battleship.Abstraction
{
    public delegate void TransmissionReceivedHandler(object sender, TransmissionReceivedArgs e);

    public class TransmissionReceivedArgs : EventArgs
    {
        public TransmissionReceivedArgs(Point target, int shotId, BattleStatus shotResultStatus)
        {
            Target = target;
            ShotId = shotId;
            ShotResultStatus = shotResultStatus;
        }
        public Point Target { get; }
        public int ShotId { get; }
        public BattleStatus ShotResultStatus { get; }
    }
}

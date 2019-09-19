using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace Battleship.Events
{
    public delegate void TransmissionReceivedHandler(object sender, TransmissionReceivedArgs e);

    public class TransmissionReceivedArgs : EventArgs
    {
        public TransmissionReceivedArgs(Point target, int shotId, BattleStatus shotResultStatus, Color team)
        {
            Target = target;
            ShotId = shotId;
            ShotResultStatus = shotResultStatus;
            Team = team;
        }
        public Color Team { get; }
        public Point Target { get; }
        public int ShotId { get; }
        public BattleStatus ShotResultStatus { get; }
    }
}

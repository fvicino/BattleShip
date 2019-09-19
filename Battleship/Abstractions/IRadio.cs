using Battleship.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Abstractions
{
    public interface IRadio
    {
        void Transmit(Point target, int shotId, BattleStatus shotResultStatus, Color team);

        event TransmissionReceivedHandler TransmissionReceived;
    }
}

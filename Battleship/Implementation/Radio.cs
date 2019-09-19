using Battleship.Abstractions;
using Battleship.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship
{
    public class Radio: IRadio
    {
        event TransmissionReceivedHandler onTransmissionSent;

        object lockObject = new object();

        public event TransmissionReceivedHandler TransmissionReceived
        {
            add
            {
                lock (lockObject)
                {
                    onTransmissionSent += value;
                }
            }

            remove
            {
                lock (lockObject)
                {
                    onTransmissionSent -= value;
                }
            }
        }

        public void Transmit(Point target, int shotId, BattleStatus shotResultStatus, Color team)
        {
            onTransmissionSent?.Invoke(this, new TransmissionReceivedArgs(target, shotId, shotResultStatus, team ));
        }

    }
}

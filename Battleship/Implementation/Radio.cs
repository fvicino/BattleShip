using Battleship.Abstraction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Implementation
{
    public class Radio: IRadio
    {
        event TransmissionReceivedHandler onTransmissionSent;

        object lockObject = new Object();

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

        public void Transmit(Point target, int shotId, BattleStatus shotResultStatus)
        {
            onTransmissionSent?.Invoke(this, new TransmissionReceivedArgs(target, shotId, shotResultStatus ));
        }

    }
}

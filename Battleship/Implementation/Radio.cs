using Battleship.Abstractions;
using Battleship.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship
{
    /// <summary>
    /// Radio service for sending and receiving messages
    /// </summary>
    public class Radio: IRadio
    {
        event TransmissionReceivedHandler onTransmissionSent;

        object lockObject = new object();

        /// <summary>
        /// Event that can be subscribed to receive messages
        /// </summary>
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

        /// <summary>
        /// Send a message using the radio service
        /// </summary>
        /// <param name="target"></param>
        /// <param name="shotId"></param>
        /// <param name="shotResultStatus"></param>
        /// <param name="team"></param>
        public void Transmit(Point target, int shotId, BattleStatus shotResultStatus, Color team)
        {
            onTransmissionSent?.Invoke(this, new TransmissionReceivedArgs(target, shotId, shotResultStatus, team ));
        }

    }
}

using Battleship.Abstractions;
using Battleship.Events;
using System;
using System.Drawing;

namespace Battleship
{

    public class BattleTheatre : IBattleTheatre
    {
        int _shotId = 0;
        public int Height { get { return 10; } }

        public int Width { get { return 10; } }

        event ShotLandedHandler onShotfired;

        object lockObject = new Object();

        public event ShotLandedHandler ShotLanded
        {
            add
            {
                lock (lockObject) {
                    onShotfired += value;
                }
            }

            remove
            {
                lock (lockObject)
                {
                    onShotfired -= value;
                }

            }
        }

        public void ShotFired(Point location)
        {
            _shotId++;
            onShotfired?.Invoke(this, new ShotEventArgs(_shotId, location));
        }
    }



}
using Battleship.Abstraction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Battleship.Implementation
{
    public class CommandCentre
    {
        Color _teamColour;
        public CommandCentre(Color teamColour, IRadio radio, IShipyard shipyard )
        {
            _teamColour = teamColour;
        }
    }
}

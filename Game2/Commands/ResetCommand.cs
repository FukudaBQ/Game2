using Game2.Interfaces;
using Game2.Sprites.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Commands
{
    class ResetCommand : ICommands
    {
        private Player player;
        public ResetCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
          player.setX(960);
          player.setY(540);
        }
    }
}


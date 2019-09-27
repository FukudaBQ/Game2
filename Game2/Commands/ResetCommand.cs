using Game2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Commands
{
    class ResetCommand : ICommands
    {
        private Game1 myGame;
        public ResetCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.player.setX(960);
            myGame.player.setY(540);
        }
    }
}


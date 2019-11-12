using Game2.Interfaces;
using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
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
        private Game1 game;
        public ResetCommand(Player player, Game1 game)
        {
            this.player = player;
            this.game = game;
        }

        public void Execute()
        {
          player.Position= new Vector2(3140, 12800);
        }
    }
}


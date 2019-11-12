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
        private HUD hud;
        public ResetCommand(Player player, Game1 game, HUD hud)
        {
            this.player = player;
            this.game = game;
            this.hud = hud;
        }

        public void Execute()
        {
          player.Position= new Vector2(3140, 12800);
            player.camPosition= new Vector2(3200, 12520);
            player.Health = 3;

        }
    }
}


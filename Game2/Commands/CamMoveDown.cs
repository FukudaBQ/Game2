﻿using Game2.Interfaces;
using Game2.Sprites.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Commands
{
    class CamMoveDown : ICommands
    {
        private Player player;
        public CamMoveDown(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.tempCam.Y = player.tempCam.Y + 880;
            if (player.MapBoundary.Contains(player.tempCam))
            {
                player.camPosition = player.tempCam;
            }
            else
            {
                player.tempCam = player.camPosition;
            }
            
        }
    }
}


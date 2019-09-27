using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Enemies
{
    class DragonStateMachine
    {
        Dragon dragon;

        public DragonStateMachine(Dragon dragon)
        {
            this.dragon= dragon;

        }

        public void ChangeColorRed()
        {
            dragon.color = Color.Red;
        }
        public void ChangeColorWhite()
        {
            dragon.color = Color.White;
        }


    }
}

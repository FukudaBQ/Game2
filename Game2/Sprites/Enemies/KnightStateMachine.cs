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
    class KnightStateMachine
    {
        private Knight knight;

        public KnightStateMachine(Knight knight)
        {
            this.knight = knight;

        }

        public void ChangeColorRed()
        {
            knight.color = Color.Red;
        }
        public void ChangeColorWhite()
        {
            knight.color = Color.White;
        }


    }
}

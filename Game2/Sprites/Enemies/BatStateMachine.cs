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
    class BatStateMachine
    {
        Bat bat;

        public BatStateMachine(Bat bat)
        {
            this.bat = bat;

        }

            public void ChangeColorRed()
        {
            bat.color = Color.Red;
        }
        public void ChangeColorWhite()
        {
            bat.color = Color.White;
        }


    }
}

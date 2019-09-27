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
    class HandStateMachine
    {
        Hand hand;

        public HandStateMachine(Hand hand)
        {
            this.hand = hand;

        }

        public void ChangeColorRed()
        {
            hand.color = Color.Red;
        }
        public void ChangeColorWhite()
        {
            hand.color = Color.White;
        }


    }
}

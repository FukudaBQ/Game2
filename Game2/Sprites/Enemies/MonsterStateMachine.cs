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
    class MonsterStateMachine
    {
        Monster monster;

        public MonsterStateMachine(Monster monster)
        {
            this.monster = monster;

        }

        public void ChangeColorRed()
        {
            monster.color = Color.Red;
        }
        public void ChangeColorWhite()
        {
            monster.color = Color.White;
        }


    }
}

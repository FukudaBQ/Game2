using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    class MouseController
    {
        private ISprite moveSprite;
        private Game1 game;
        public MouseController(Game1 game)
        {
            Mouse.SetPosition(200, 200);
            this.game = game;

        }
        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            int x = mouseState.X;
            int y = mouseState.Y;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
            }
        }
    }
}

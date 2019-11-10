using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Sprites.Link.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Game2.Sprites.Link
{
    class BombHandler
    {
        private Vector2 position;
        private Dir direction;


        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (BombProj proj in BombProj.bomb)
            {
                proj.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw, List<BombProj> bombToDraw)
        {
            foreach (BombProj i in bombToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
            }
        }
    }
}


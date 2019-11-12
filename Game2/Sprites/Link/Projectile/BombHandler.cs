using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Sprites.Enemies;
using Game2.Sprites.Link.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Game2.Sprites.Link
{
    class BombHandler
    {


        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (BombProj proj in BombProj.bomb)
            {
                proj.Update(gameTime);
                if (proj.Timer <= 0)
                {
                    explosion.exp.Add(new explosion(proj.Position));
                }


            }
            foreach (explosion ex in explosion.exp)
            {
                ex.Update(gameTime);

            }

            BombProj.bomb.RemoveAll(proj => proj.Timer <= 0);
            explosion.exp.RemoveAll(ex => ex.Timer <= 0);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw, List<BombProj> bombToDraw, Texture2D explosionSprite)
        {
            foreach (BombProj i in bombToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
                foreach (explosion ex in explosion.exp)
                {
                    spriteBatch.Draw(explosionSprite, ex.Position, Color.White);
                }
            }

        }
    }
}


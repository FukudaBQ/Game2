using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Game2.Sprites.Link
{
    class ProjectileHandler
    {
        private Vector2 position;
        private Dir direction;


        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Projectile proj in Projectile.bomb)
            {
                /*switch (direction)
                {
                    case Dir.Right:
                        position.X -= 30;
                        break;
                    case Dir.Left:
                        position.X += 30;
                        break;
                    case Dir.Up:
                        position.Y += 30;
                        break;
                    case Dir.Down:
                        position.Y -= 30;
                        break;
                    default:
                        break;
                }*/
                //proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.arrowDown)
            {
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.arrowUp)
            {
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.arrowLeft)
            {
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.arrowRight)
            {
                proj.Update(gameTime);
            }
            foreach (Projectile proj in Projectile.boomerang)
            {
                proj.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw,List<Projectile> projListToDraw)
        {
            foreach (Projectile i in projListToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
            }
        }
    }
}

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


        public void Update(GameTime gameTime)
        {
            foreach (Projectile proj in Projectile.bomb)
            {
                proj.Update(gameTime);
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
       
        





           /*foreach (Projectile i in Projectile.arrowDown)
           {
               spriteBatch.Draw(arrowDown, i.Position, Color.White);
           }
           foreach (Projectile i in Projectile.arrowUp)
           {
               spriteBatch.Draw(arrowUp, i.Position, Color.White);
           }
           foreach (Projectile i in Projectile.arrowLeft)
           {
               spriteBatch.Draw(arrowLeft, i.Position, Color.White);
           }
           foreach (Projectile i in Projectile.arrowRight)
           {
               spriteBatch.Draw(arrowRight, i.Position, Color.White);
           }
           foreach (Projectile i in Projectile.boomerang)
           {
               spriteBatch.Draw(boomerang, i.Position, Color.White);
           }*/

        }
    }

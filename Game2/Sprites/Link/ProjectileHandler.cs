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
            foreach (bombProj proj in bombProj.bomb)
            {
                proj.Update(gameTime);
            }
            foreach (arrowProj proj in arrowProj.arrowDown)
            {
                proj.Update(gameTime);
            }
            foreach (arrowProj proj in arrowProj.arrowUp)
            {
                proj.Update(gameTime);
            }
            foreach (arrowProj proj in arrowProj.arrowLeft)
            {
                proj.Update(gameTime);
            }
            foreach (arrowProj proj in arrowProj.arrowRight)
            {
                proj.Update(gameTime);
            }
            foreach (boomerangProj proj in boomerangProj.boomerang)
            {
                proj.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw,List<bombProj> projListToDraw)
        {
            foreach (bombProj i in projListToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
            }
        }
    }
}

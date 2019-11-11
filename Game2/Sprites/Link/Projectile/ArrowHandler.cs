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
    class ArrowHandler
    {
        private Vector2 position;
        private Dir direction;


        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (ArrowProj proj in ArrowProj.arrowDown)
            {
                proj.Update(gameTime);
            }
            foreach (ArrowProj proj in ArrowProj.arrowUp)
            {
                proj.Update(gameTime);
            }
            foreach (ArrowProj proj in ArrowProj.arrowLeft)
            {
                proj.Update(gameTime);
                
            }
            foreach (ArrowProj proj in ArrowProj.arrowRight)
            {
                proj.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw, List<ArrowProj> arrowToDraw)
        {
            foreach (ArrowProj i in arrowToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
            }
        }
    }
}

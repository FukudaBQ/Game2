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
    class BoomerangHandler
    {
        private Vector2 position;
        private Dir direction;
        private float timeLastUpdate=0f;


        public void Update(GameTime gameTime)
        {
            //float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //timeLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (BoomerangProj proj in BoomerangProj.boomerang)
            {
                proj.Update(gameTime);
               
            }
            //BoomerangProj.boomerang.RemoveAll(proj => proj.);
            
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw,List<BoomerangProj> boomerangToDraw)
        {
            foreach (BoomerangProj i in boomerangToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
            }
        }
    }
}

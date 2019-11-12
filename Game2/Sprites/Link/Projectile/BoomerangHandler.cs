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


        public void Update(GameTime gameTime,Player player)
        {
            //float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (BoomerangProj proj in BoomerangProj.boomerang)
            {
                proj.Update(gameTime,player);
                if (timeLastUpdate >2.0f)
                {
                    proj.IsBack = true;
                    timeLastUpdate = 0;
                }
            }
            BoomerangProj.boomerang.RemoveAll(proj => proj.Position==(player.Position));
            
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

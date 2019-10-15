using Game2.Object.Items;
using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Collision
{
    class Collision
    {
        private CollisionDetection collisionDetection;
        private CollisionHandler collisionHandler;
        public Collision(Key key, Player link, Texture2D texture)
        {
            collisionDetection = new CollisionDetection(key, link, texture);
            collisionHandler = new CollisionHandler();
        }
        
        public void Update(GameTime gameTime)
        {
            //List<T> DetectedCollision = collisionDetection.getCollisions();
            //collisionDetection.update(DetectedCollision);
        }
    }
}

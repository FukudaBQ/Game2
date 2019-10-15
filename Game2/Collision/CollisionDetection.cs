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
    class CollisionDetection
    {
        private Vector2 LinkPos;
        private Rectangle destinationRectangleLink;
        private Rectangle destinationRectanglekey;
        private Key key;
        private Player link;
        public CollisionDetection(Key key, Player link, Texture2D texture)
        {
            this.key = key;
            this.link = link;
            //this.destinationRectanglekey = this.key.destinationRectangle;
            //this.LinkPos = link.position;
            //this.destinationRectangleLink = new Rectangle((int)LinkPos.X, (int)LinkPos.Y, texture.Width/2, texture.Height);
        }

        public void DetectCollision()
        {
            if (destinationRectanglekey.Intersects(destinationRectangleLink))
            {
                
                Console.Write("\nTrue\n");
            }
        }
    }
}

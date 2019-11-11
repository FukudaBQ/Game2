using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class HUD
    {
        private Player player;
        private Texture2D texture;
        private SpriteBatch batch;
        private HUDHeart heart;

        public HUD(Player player, Texture2D texture, SpriteBatch batch)
        {
            this.player = player;
            this.texture = texture;
            this.batch = batch;
            heart = new HUDHeart();
        }

        public void updateHeartLoc(int X, int Y)
        {
            heart.UpdateLoc(X, Y);
        }

        public void Draw()
        {
            heart.Draw(texture, batch);
        }

        public int getDestX()
        {
            return heart.getDestX();
        }

        public int getDestY()
        {
            return heart.getDestY();
        }
        private class HUDHeart
        {
            private int sourceX = 645;
            private int sourceY = 117;
            private int sourceWidth = 8;
            private int sourceHeight = 8;
            private int destX = 6200;
            private int destY = 3900;
            private int destWidth = 70;
            private int destHeight = 70;

            public int getDestX() {
                return destX;
            }

            public int getDestY()
            {
                return destY;
            }
            public HUDHeart() { }



            internal void Draw(Texture2D texture, SpriteBatch batch)
            {
                Rectangle sourceRectangle = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                Rectangle destinationRectangle = new Rectangle(destX, destY, destWidth, destHeight);
                batch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }

            internal void UpdateLoc(int destX, int destY)
            {
                this.destX = destX;
                this.destY = destY;
            }
        }
    }
}

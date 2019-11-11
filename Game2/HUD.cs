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

        public void updateHeartLoc()
        {
            Vector2 pos = player.getCamPosition();
            heart.UpdateLoc((int)pos.X, (int)pos.Y);
        }

        public void Draw()
        {
            heart.Draw(texture, batch);
        }
        private class HUDHeart
        {
            private int sourceX = 645;
            private int sourceY = 117;
            private int sourceWidth = 7;
            private int sourceHeight = 7;
            private int destX;
            private int destY;
            private int destWidth = 7;
            private int destHeight = 7;

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

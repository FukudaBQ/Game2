using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDManager
{
    class HUDHeart
    {
        private int sourceX = 645;
        private int sourceY = 117;
        private int sourceWidth = 7;
        private int sourceHeight = 7;
        private int destX;
        private int destY;
        private int destWidth = 50;
        private int destHeight = 50;
        private int currentX;
        private int currentY;

        public HUDHeart(int destX, int destY)
        {
            this.destX = destX;
            this.destY = destY;
        }

        public int getX()
        {
            return destX;
        }

        public int getY()
        {
            return destY;
        }

        internal void Draw(Texture2D texture, SpriteBatch batch)
        {
            Rectangle sourceRectangle = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
            Rectangle destinationRectangle = new Rectangle(destX + currentX * 1280, destY + currentY * 2040, destWidth, destHeight);
            batch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        internal void UpdateLoc(int destX, int destY)
        {
            this.destX = destX;
            this.destY = destY;
        }
        internal void moveRight()
        {
            currentX++;
        }
        internal void moveLeft()
        {
            currentX--;
        }
        internal void moveUp()
        {
            currentY--;
        }
        internal void moveDown()
        {
            currentY++;
        }
    }
}

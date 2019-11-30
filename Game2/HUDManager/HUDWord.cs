using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDManager
{
    class HUDWord
    {
        private int[] sourceX = { 528, 537, 546, 555, 564, 574, 582, 591, 600, 609, 519 };
        private int sourceY = 117;
        private int sourceWidth = 8;
        private int sourceHeight = 8;
        private int destX;
        private int destY;
        private int destWidth = 25;
        private int destHeight = 25;
        private int k;
        private int currentX = 0;
        private int currentY = 0;

        public HUDWord(int destX, int destY, int k)
        {
            this.destX = destX;
            this.destY = destY;
            this.k = k;
        }

        public int getX()
        {
            return currentX;
        }

        public int getY()
        {
            return currentY;
        }
        internal void Draw(Texture2D texture, SpriteBatch batch)
        {
            Rectangle sourceRectangle = new Rectangle(sourceX[k], sourceY, sourceWidth, sourceHeight);
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

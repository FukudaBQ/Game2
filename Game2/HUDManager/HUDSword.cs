using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDManager
{
    class HUDSword
    {
        private int sourceX = 555;
        private int sourceY = 137;
        private int sourceWidth = 8;
        private int sourceHeight = 16;
        private int destX = 3330;
        private int destY = 12030;
        private int destWidth = 50;
        private int destHeight = 100;
        private int currentX;
        private int currentY;

        public HUDSword()
        {
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

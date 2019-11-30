using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDManager
{
    class HUDMap
    {
        private int sourceX = 0;
        private int sourceY = 0;
        private int sourceWidth = 275;
        private int sourceHeight = 138;
        private int destX = 2640;
        private int destY = 11980;
        private int destWidth = 200;
        private int destHeight = 200;
        // variables for index box
        private int indexSourceX = 0;
        private int indexSourceY = 0;
        private int indexSourceWidth = 10;
        private int indexSourceHeight = 20;
        private int indexDestX = 80;
        private int indexDestY = 170;
        private int indexDestWidth = 10;
        private int indexDestHeight = 20;
        private int distX = 33;
        private int distY = 33;
        private int currentX = 0;
        private int currentY = 0;

        public HUDMap() { }

        public int getX()
        {
            return destX;
        }

        public int getY()
        {
            return destY;
        }

        internal void Draw(Texture2D texture, SpriteBatch batch, Texture2D green)
        {
            Rectangle sourceRectangle = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
            Rectangle destinationRectangle = new Rectangle(destX, destY, destWidth, destHeight);
            batch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            Rectangle indexSourceRectangle = new Rectangle(indexSourceX, indexSourceY, indexSourceWidth, indexSourceHeight);
            Rectangle indexDestinationRectangle = new Rectangle(destX + indexDestX + distX * currentX, destY + indexDestY + distY * currentY,
                indexDestWidth, indexDestHeight);
            batch.Draw(green, indexDestinationRectangle, indexSourceRectangle, Color.Yellow);
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

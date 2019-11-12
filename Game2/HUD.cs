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
        private Texture2D mapTexture;
        private SpriteBatch batch;
        private HUDHeart heart;
        private HUDMap map;
        private Texture2D green;
        private HUDWord[] wordKey;
        private int[] keyNumX = {5620, 5645, 5670 };
        private int keyNumY = 3920;

        public HUD(Player player, Texture2D texture, SpriteBatch batch, Texture2D mapTexture, Texture2D veryGreen)
        {
            this.player = player;
            this.texture = texture;
            this.mapTexture = mapTexture;
            this.batch = batch;
            this.green = veryGreen;
            heart = new HUDHeart(6200, 3920);
            map = new HUDMap();
            wordKey = new HUDWord[3];
            RegisterKey();

        }

        private void RegisterKey()
        {
            wordKey[0] = new HUDWord(keyNumX[0], keyNumY, 10);
            wordKey[1] = new HUDWord(keyNumX[1], keyNumY, 0);
            wordKey[2] = new HUDWord(keyNumX[2], keyNumY, 0);
        }

        public void KeyNumUpdate(int numOfKeys)
        {
            int tenth = numOfKeys / 10;
            int num = numOfKeys % 10;
            wordKey[1] = new HUDWord(wordKey[1].getX(), wordKey[1].getY(), tenth);
            wordKey[2] = new HUDWord(wordKey[2].getX(), wordKey[2].getY(), num);
        }

        public void KeyNumUp()
        {
            foreach (HUDWord i in wordKey)
            {
                i.moveUp();
            }
        }

        public void KeyNumDown()
        {
            foreach (HUDWord i in wordKey)
            {
                i.moveDown();
            }
        }
        public void KeyNumLeft()
        {
            foreach (HUDWord i in wordKey)
            {
                i.moveLeft();
            }
        }
        public void KeyNumRight()
        {
            foreach (HUDWord i in wordKey)
            {
                i.moveRight();
            }
        }

        public void updateHeartLoc(int X, int Y)
        {
            heart.UpdateLoc(X, Y);
        }
        public void updateMapLoc(int X, int Y)
        {
            map.UpdateLoc(X, Y);
        }
        public int getMapDestX()
        {
            return map.getX();
        }
        public int getMapDestY()
        {
            return map.getY();
        }

        public void indexUp()
        {
            map.moveUp();
        }

        public void indexDown()
        {
            map.moveDown();
        }
        public void indexLeft()
        {
            map.moveLeft();
        }
        public void indexRight()
        {
            map.moveRight();
        }

        public void Draw()
        {
            heart.Draw(texture, batch);
            map.Draw(mapTexture, batch, green);
            foreach (HUDWord i in wordKey)
            {
                i.Draw(texture, batch);
            }
        }
        public int getHeartDestX()
        {
            return heart.getX();
        }
        public int getHeartDestY()
        {
            return heart.getY();
        }

        /*
         * internal class of heart
         */
        private class HUDHeart
        {
            private int sourceX = 645;
            private int sourceY = 117;
            private int sourceWidth = 7;
            private int sourceHeight = 7;
            private int destX;
            private int destY;
            private int destWidth = 50;
            private int destHeight = 50;

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
                Rectangle destinationRectangle = new Rectangle(destX, destY, destWidth, destHeight);
                batch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }

            internal void UpdateLoc(int destX, int destY)
            {
                this.destX = destX;
                this.destY = destY;
            }
        }


        private class HUDSword
        {

        }

        /*
         * Internal class Map
         */
        private class HUDMap
        {
            private int sourceX = 0;
            private int sourceY = 0;
            private int sourceWidth = 275;
            private int sourceHeight = 138;
            private int destX = 5200;
            private int destY = 3820;
            private int destWidth = 200;
            private int destHeight = 200;
            // variables for index box
            private int indexSourceX = 0;
            private int indexSourceY = 0;
            private int indexSourceWidth = 10;
            private int indexSourceHeight = 20;
            private int indexDestX = 150;
            private int indexDestY = 40;
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
                batch.Draw(green, indexDestinationRectangle, indexSourceRectangle, Color.Green);
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

        /*
         * Internal class HUDWord
         */
        private class HUDWord
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
                return destX;
            }

            public int getY()
            {
                return destY;
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
}

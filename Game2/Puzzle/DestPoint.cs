using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Puzzle
{
    class DestPoint
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int width = 13;
        private int height = 18;
        private int locationX;
        private int locationY;
        private int sourceX = 14;
        private int sourceY = 18;
        private int blockWidth = 20;
        private int blockHeight = 20;
        public DestPoint(Texture2D texture, SpriteBatch spriteBatch, int X, int Y)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.locationX = X;
            this.locationY = Y;
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(sourceX, sourceY, width, height);
            Rectangle destinationRectangle = new Rectangle(locationX, locationY, blockWidth, blockHeight);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.LightPink);
        }

        public int getLocX()
        {
            return locationX;
        }

        public int getLocY()
        {
            return locationY;
        }
    }
}

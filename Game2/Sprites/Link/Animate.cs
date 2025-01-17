﻿using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    public class Animate
    {
        private Texture2D Texture { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int totalFrame;
        private float timeLastUpdate = 0f;

        public Animate(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrame = rows*columns;
        }

        public void Update(GameTime gameTime)
        {
            //currentFrame++;
            //if (currentFrame == totalFrames)
            //  currentFrame = 0;
            timeLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeLastUpdate > 0.2f)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                timeLastUpdate = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location,Color color)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

           // spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, color);
           // spriteBatch.End();
        }
        public void setFrame(int newFrame)
        {
            currentFrame = newFrame;
        }
        
    }
}

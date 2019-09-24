﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Items
{
    public class Rupy : ISprite
    {
        public Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        int currentFrame;
        int totalFrame;
        float timeLastUpdate = 0f;
        public Rupy(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 3;
        }
        public void Update(GameTime gametime)
        {
            timeLastUpdate += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (timeLastUpdate > 0.1f)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                timeLastUpdate = 0f;
            }
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(240 + currentFrame * 30, 48, 20, 40);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 40);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
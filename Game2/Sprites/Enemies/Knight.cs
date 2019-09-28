using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Enemies
{
    class Knight : ISprite
    {
        private Texture2D texture { get; set; }
        private Vector2 location { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private int currentFrame;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        private bool hitted = true;
        public Color color = Color.White;
        private KeyboardState previous = Keyboard.GetState();
        private KnightStateMachine stateMachine;
        public Knight(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 2;
            stateMachine = new KnightStateMachine(this);
        }
        public void Update(GameTime gametime)
        {
            timeLastUpdate += (float)gametime.ElapsedGameTime.TotalSeconds;

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
        public void Draw()
        {
            KeyboardState kState = Keyboard.GetState();


            if (kState.IsKeyDown(Keys.O) && previous.IsKeyUp(Keys.O) && hitted)
            {
                stateMachine.ChangeColorRed();
                hitted = !hitted;
            }
            else if (kState.IsKeyDown(Keys.O) && previous.IsKeyUp(Keys.O) && !hitted)
            {
                stateMachine.ChangeColorWhite();
                hitted = !hitted;
            }
            previous = kState;
            Rectangle sourceRectangle = new Rectangle(0, 0 + currentFrame * 30, 18, 18);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}

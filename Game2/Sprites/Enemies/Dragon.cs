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
    class Dragon : ISprite
    {
        private Texture2D texture { get; set; }
        private Vector2 location { get; set; }
        private SpriteBatch spriteBatch { get; set; }
        private int currentFrame;
        private bool hitted = true;
        public Color color = Color.White;
        private KeyboardState previous = Keyboard.GetState();
        private DragonStateMachine stateMachine;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        public Dragon(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 4;
            stateMachine = new DragonStateMachine(this);
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


            if (kState.IsKeyDown(Keys.T) && previous.IsKeyUp(Keys.T) && hitted)
            {
                stateMachine.ChangeColorRed();
                hitted = !hitted;
            }
            else if (kState.IsKeyDown(Keys.T) && previous.IsKeyUp(Keys.T) && !hitted)
            {
                stateMachine.ChangeColorWhite();
                hitted = !hitted;
            }
            previous = kState;
            Rectangle sourceRectangle = new Rectangle(currentFrame * 41, 1, 45, 46);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 41 * 4, 46 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}

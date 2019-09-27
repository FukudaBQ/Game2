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
    class Monster : ISprite
    {
        public Texture2D texture { get; set; }
        public Vector2 location { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        int currentFrame;
        int totalFrame;
        float timeLastUpdate = 0f;
        public bool hitted = true;
        public Color color = Color.White;
        KeyboardState previous = Keyboard.GetState();
        MonsterStateMachine stateMachine;
        public Monster(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 2;
            stateMachine = new MonsterStateMachine(this);
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


            if (kState.IsKeyDown(Keys.U) && previous.IsKeyUp(Keys.U) && hitted)
            {
                stateMachine.ChangeColorRed();
                hitted = !hitted;
            }
            else if (kState.IsKeyDown(Keys.U) && previous.IsKeyUp(Keys.U) && !hitted)
            {
                stateMachine.ChangeColorWhite();
                hitted = !hitted;
            }
            previous = kState;
            Rectangle sourceRectangle = new Rectangle(0, 1 + currentFrame * 30, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}

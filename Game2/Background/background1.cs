using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Background
{
    class Background1
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch batch;
        private int nextrow = 515;
        private int nextcolumn = 532;
        private GraphicsDevice graphics;
        private int fullScreenX;
        private int fullScreenY;
        public Background1(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.position = location;
            this.batch = batch;
            this.graphics = texture.GraphicsDevice;
            fullScreenX = graphics.Viewport.Width;
            fullScreenY = graphics.Viewport.Height;
        }
        public void Update(GameTime gametime)
        {
            MouseState mouseState = Mouse.GetState();
            int x = mouseState.X;
            int y = mouseState.Y;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (y > 400 && y < 500 && x < 850)
                {
                    nextrow -= 20;
                }
                else if (y > 400 && y < 500 && x > 850)
                {
                    nextrow += 20;
                }
                else if (x > 650 && x < 700 && y < 500)
                {
                    nextcolumn -= 14;
                }
                else if (x > 620 && x < 670 && y > 900)
                {
                    nextcolumn += 13;
                }
            }
        }
        public void Draw()
        {
            Rectangle SourceReatangle = new Rectangle(0 + nextrow, 0 + nextcolumn, 256, 180);
            batch.Draw(texture, new Rectangle(0, 0, fullScreenX, fullScreenY), SourceReatangle, Color.White);
        }
    }
}

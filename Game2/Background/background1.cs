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
        private int nextrow = 520;
        private int nextcolumn = 546;
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
                /*if (y > 593 && y < 653 && x < 564)
                {
                    nextrow -= 251;
                }*/
                if (y > 300 && y < 600 && x < 300)
                {
                    nextrow -= 20;
                }
                else if (y > 593 && y < 653 && x > 700)
                {
                    nextrow += 19;
                }
                else if (x > 620 && x < 670 && y < 600)
                {
                    nextcolumn -= 14;
                }
                else if (x > 620 && x < 670 && y > 656)
                {
                    nextcolumn += 15;
                }
            }
        }
        public void Draw()
        {
            Rectangle SourceReatangle = new Rectangle(0 + nextrow, 0 + nextcolumn, 251, 160);
            batch.Draw(texture, new Rectangle(0, 0, fullScreenX, fullScreenY), SourceReatangle, Color.White);
        }
    }
}

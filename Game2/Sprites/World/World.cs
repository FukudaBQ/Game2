using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.World
{
    class Wolrd
    {
        private Texture2D texture;
        private Vector2 position;
        private SpriteBatch batch;
        private int nextrow = 0;
        private int nextcolumn = 2;
        private GraphicsDevice graphics;
        private int fullScreenX;
        private int fullScreenY;
        private float timeLastUpdate = 0;
        public Wolrd(Texture2D texture, Vector2 location, SpriteBatch batch)
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
            timeLastUpdate += (float)gametime.ElapsedGameTime.TotalSeconds;
            KeyboardState KState = Keyboard.GetState();
            if (KState.IsKeyDown(Keys.I))
            {
                if(timeLastUpdate < 6)
                    nextrow += 258/6;
            }
            if (KState.IsKeyDown(Keys.J))
            {
                nextcolumn += 175;
            }
        }
        public void Draw()
        {
            Rectangle SourceReatangle = new Rectangle(0 + nextrow, 0 + nextcolumn, 258, 175);
            batch.Draw(texture, new Rectangle(0,0, fullScreenX, fullScreenY), SourceReatangle, Color.White);
        }
    }
}

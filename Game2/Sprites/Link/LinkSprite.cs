using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Link
{
    class LinkSpriteBasics : ISprite
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private Vector2 position;
        public int x;
        public int y;
        private int width = 25;
        private int height = 25;
        public LinkSpriteBasics(Texture2D texture, SpriteBatch spriteBatch, Vector2 position) {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.position = position;
        }
        public virtual void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(x, y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }

    class LinkSpriteFaceDown : LinkSpriteBasics
    {
        public LinkSpriteFaceDown(Texture2D texture, SpriteBatch spriteBatch, Vector2 position):base(texture, spriteBatch, position)
        {
            x = 1;
            y = 0;
        }
        public override void Draw()
        {
            base.Draw();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }

    class LinkSpriteFaceUp : LinkSpriteBasics
    {
        public LinkSpriteFaceUp(Texture2D texture, SpriteBatch spriteBatch, Vector2 position) : base(texture, spriteBatch, position)
        {
            x = 51;
            y = 0;
        }
        public override void Draw()
        {
            base.Draw();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }

    class LinkSpriteFaceLeft : LinkSpriteBasics
    {
        public LinkSpriteFaceLeft(Texture2D texture, SpriteBatch spriteBatch, Vector2 position) : base(texture, spriteBatch, position)
        {
            x = 26;
            y = 0;
        }
        public override void Draw()
        {
            base.Draw();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }

    class LinkSpriteFaceRight : LinkSpriteBasics
    {
        public LinkSpriteFaceRight(Texture2D texture, SpriteBatch spriteBatch, Vector2 position) : base(texture, spriteBatch, position)
        {
            x = 76;
            y = 0;
        }
        public override void Draw()
        {
            base.Draw();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}

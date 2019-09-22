using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game2.Interfaces;
using Game2.Sprites.Link;

namespace Game2.Factory
{
    class LinkSpriteFactory
    {
        private Texture2D redLink;
        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            redLink = content.Load<Texture2D>("Link");
        }

        public ISprite CreateRedLinkSprite(SpriteBatch spriteBatch, Vector2 position)
        {
            return new LinkSpriteFaceDown(redLink, spriteBatch, position);
        }
    }
}

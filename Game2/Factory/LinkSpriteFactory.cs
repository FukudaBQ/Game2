using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Game2.Interfaces;
using Game2.Sprites.Link;

namespace Game2.Factory
{
    class LinkSpriteFactory
    {
        Texture2D moveDown;
        Texture2D moveUp;
        Texture2D moveLeft;
        Texture2D moveRight;
        Texture2D downSword;
        Texture2D upSword;
        Texture2D leftSword;
        Texture2D rightSword;
        Texture2D dying;
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
            moveDown = content.Load<Texture2D>("LinkFaceFront");
            moveUp = content.Load<Texture2D>("LinkBackWalking");
            moveLeft = content.Load<Texture2D>("LinkLeftWalking");
            moveRight = content.Load<Texture2D>("LinkRightWalking");
            downSword = content.Load<Texture2D>("LinkSwingSwordFrontStand");
            upSword = content.Load<Texture2D>("LinkSwingSwordBackStand");
            leftSword = content.Load<Texture2D>("LinkSwingSwordLeftStand");
            rightSword = content.Load<Texture2D>("LinkSwingSwordRightStand");
            dying = content.Load<Texture2D>("LinkStand4Directions");
        }

        public Animate CreateMoveDown(int rows, int columns)
        {
            return new Animate(moveDown, rows, columns);

        }
        public Animate CreateMoveUp(int rows, int columns)
        {
            return new Animate(moveUp, rows, columns);

        }
        public Animate CreateMoveLeft(int rows, int columns)
        {
            return new Animate(moveLeft, rows, columns);

        }
        public Animate CreateMoveRight(int rows, int columns)
        {
            return new Animate(moveRight, rows, columns);

        }
        public Animate CreateDownSword(int rows, int columns)
        {
            return new Animate(downSword, rows, columns);

        }
        public Animate CreateUpSword(int rows, int columns)
        {
            return new Animate(upSword, rows, columns);

        }
        public Animate CreateLeftSword(int rows, int columns)
        {
            return new Animate(leftSword, rows, columns);

        }
        public Animate CreateRightSword(int rows, int columns)
        {
            return new Animate(rightSword, rows, columns);

        }
        public PlayerDying CreateDying(Vector2 position, SpriteBatch batch)
        {
            //return new PlayerDying(dying, position, batch);
            return new PlayerDying(dying, 2,3);
        }

    }
}

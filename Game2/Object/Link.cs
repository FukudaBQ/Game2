using Game2.Factory;
using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Object
{
    class Link
    {
        private LinkStateMachine stateMachine;
        private SpriteBatch spriteBatch;
        public Link(SpriteBatch spriteBatch)
        {
            stateMachine = new LinkStateMachine();
            this.spriteBatch = spriteBatch;
        }

        public void changeDirection()
        {

        }


        public void Draw()
        {
            ISprite nonMovingNonAnimated = LinkSpriteFactory.Instance.CreateRedLinkSpriteFaceUp(spriteBatch, new Vector2(100, 100));
            nonMovingNonAnimated.Draw();
        }

        public void Update()
        {

        }

    }

    public class LinkStateMachine
    {

        

        public void Update()
        {
            // if-else logic based on the current values of facingLeft and health to determine how to move
        }
    }
}

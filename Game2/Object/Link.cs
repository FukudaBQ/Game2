using Game2.Factory;
using Game2.Interfaces;
using Game2.Sprites;
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

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }

        public void BeStomped()
        {
            stateMachine.BeStomped();
        }

        public void BeFlipped()
        {
            stateMachine.BeFlipped();
        }

        public void Draw()
        {
            ISprite nonMovingNonAnimated = LinkSpriteFactory.Instance.CreateRedLinkSprite(spriteBatch, new Vector2(100, 100));
            nonMovingNonAnimated.Draw();
        }

    }

    public class LinkStateMachine
    {
        private bool facingLeft = true;
        private enum GoombaHealth { Normal, Stomped, Flipped };
        private GoombaHealth health = GoombaHealth.Normal;
        public void BeFlipped()
        {
            if (health != GoombaHealth.Flipped) // Note: the if is needed so we only do the transition once
            {
                health = GoombaHealth.Flipped;
                // Compute and construct goomba sprite - requires if-else logic with value of health
            }
        }

        public void BeStomped()
        {
            if (health != GoombaHealth.Stomped) // Note: the if is needed so we only do the transition once
            {
                health = GoombaHealth.Stomped;
                // Compute and construct goomba sprite - requires if-else logic with value of health
            }
        }

        public void ChangeDirection()
        {
            facingLeft = !facingLeft;
        }

        public void Update()
        {
            // if-else logic based on the current values of facingLeft and health to determine how to move
        }
    }
}

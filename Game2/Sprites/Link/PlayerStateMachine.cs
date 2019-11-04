using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.Sprites.Link
{

    class PlayerStateMachine
    {
        private Dir direction = Dir.Down;
        private bool isMoving = false;
        private bool isSwording = false;
        private int speed = 200;
        private int radius = 20;
        Player player;
        private static Dictionary<Dir, Dir> changeToSword = new Dictionary<Dir, Dir>()
        {
            {Dir.Down, Dir.DownSword },
            {Dir.Left, Dir.LeftSword },
            {Dir.Right, Dir.RightSword },
            {Dir.Up, Dir.UpSword }
        };
        private Vector2 position = new Vector2(960, 540);
        private KeyboardState previous = Keyboard.GetState();
        private Dictionary<Dir, Animate> facing = new Dictionary<Dir, Animate>();
        public Animate[] ani = new Animate[7];

        public bool ifIsMoving()
        {
            return isMoving;
        }

        public bool ifIsSwording()
        {
            return isSwording;
        }

        public Dir getDirection()
        {
            return direction;
        }
        public void ChangeDirectionLeft()
        {
            direction = Dir.Left;
            isMoving = true;
        }
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public void SetFacing()
        {

        }

        public PlayerStateMachine(Player player)
        {
            this.player = player;

        }
        public void ChangeDirectionRight()
        {
            direction = Dir.Right;
            isMoving = true;
        }
        public void ChangeDirectionUp()
        {
            direction = Dir.Up;
            isMoving = true;
        }
        public void ChangeDirectionDown()
        {
            direction = Dir.Down;
            isMoving = true;
        }

        private void UseSword()
        {
            if (direction == Dir.Down || direction == Dir.Up
                || direction == Dir.Left || direction == Dir.Right)
            {
                direction = changeToSword[direction];
                MySounds.attack.Play();

            }
            isSwording = true;


            isMoving = true;
        }

        public void Update(GameTime gameTime)
        {
            isMoving = isSwording = false;
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.A) || kState.IsKeyDown(Keys.Left))
            {
                ChangeDirectionLeft();
            }
            if (kState.IsKeyDown(Keys.D) || kState.IsKeyDown(Keys.Right))
            {
                ChangeDirectionRight();
            }
            if (kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.Up))
            {
                ChangeDirectionUp();
            }
            if (kState.IsKeyDown(Keys.S) || kState.IsKeyDown(Keys.Down))
            {
                ChangeDirectionDown();
            }
            if (kState.IsKeyDown(Keys.Z) || kState.IsKeyDown(Keys.N))
            {
                UseSword();
                
            }

        }

    }
}

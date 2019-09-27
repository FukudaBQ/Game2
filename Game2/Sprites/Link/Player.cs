using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Commands;
using Game2.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.Sprites.Link
{
    public class Player
    {
        
        public Vector2 position = new Vector2(960, 540);
        private int speed = 200;
        private Dir direction = Dir.Down;
        private bool isMoving = false;
        private bool isSwording = false;
        public Animate anim;
        private PlayerStateMachine stateMachine;
        private Dictionary<Dir, Animate> facing = new Dictionary<Dir, Animate>();
        public int radius=20;
        public Animate[] ani = new Animate[7];
        private KeyboardState previous = Keyboard.GetState();
        private ExitCommand exit;
        private ResetCommand reset;
        private Dictionary<Dir, Animate>facing = new Dictionary<Dir, Animate>();
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        public void setX(float newX)
        {
            position.X = newX;
        }
        public void setY(float newY)
        {
            position.Y = newY;
        }
        public Player(Game1 game)
        {
            exit = new ExitCommand(game);
            stateMachine = new PlayerStateMachine(this);
            reset = new ResetCommand(game);
            facing.Add(Dir.Down, LinkSpriteFactory.Instance.CreateMoveDown(1, 2));
            anim = facing[direction];

        }


        public void Update(GameTime gameTime)
        {
            stateMachine.Update(gameTime);
            
           
        }
    }

 
}

using Game2.Object.Items;
using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Puzzle
{
    public class Sokoban
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int[] baggageX = {5840, 6000, 6160};
        private int[] baggageY = { 12600, 12600, 12600};
        private int[] destX = { 5870, 6030, 6190};
        private int[] destY = {12710, 12710, 12710};
        private List<Baggage> baggage = new List<Baggage>();
        private List<DestPoint> dest = new List<DestPoint>();
        private List<bool> arrived = new List<bool>();
        private int blockWidth = 80;
        private int blockHeight = 80;
        private int upLimit;
        private int downLimit;
        private int leftLimit;
        private int rightLimit;
        private BlackHole blackHole;
        private bool success = false;
        private Texture2D blackHoleSprite;
        private Texture2D text;
        public Sokoban(Texture2D texture, SpriteBatch spriteBatch, int upLimit, 
            int downLimit, int leftLimit, int rightLimit, Texture2D blackHoleSprite, Texture2D textForExtraContent)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.upLimit = upLimit;
            this.downLimit = downLimit;
            this.leftLimit = leftLimit;
            this.rightLimit = rightLimit;
            this.blackHoleSprite = blackHoleSprite;
            this.text = textForExtraContent;
            populate();
        }

        public Vector2 Update(GameTime gameTime, Player player, int command, Vector2 camPos)
        {
            if (success)
            {
                
                Vector2 camLoc = blackHole.Update( gameTime, player, command, player.camPosition);
                Console.WriteLine(camLoc);
                return camLoc;
            }
            return player.camPosition;
        }

        private void populate()
        {
            for(int i = 0; i < baggageX.Length; i ++)
            {
                baggage.Add(new Baggage(texture, spriteBatch, baggageX[i], baggageY[i], upLimit, downLimit, leftLimit, rightLimit));
                dest.Add(new DestPoint(texture, spriteBatch, destX[i], destY[i]));
                arrived.Add(false);
            }
        }

        public void Draw()
        {
            foreach (DestPoint i in dest)
            {
                i.Draw();
            }
            foreach (Baggage i in baggage)
            {
                i.Draw();
            }
            spriteBatch.Draw(text, new Rectangle(5080, 11960, 1300, 200), Color.White);
        }
        public void Push(Dir direction, Vector2 position)
        {
            switch (direction)
            {
                case Dir.UpSword:

                case Dir.Up:
                    PushUP(direction, position);
                    CheckSuccess();
                    break;
                case Dir.DownSword:
                case Dir.Down:
                    PushDown(direction, position);
                    CheckSuccess();
                    break;
                case Dir.LeftSword:
                case Dir.Left:
                    PushLeft(direction, position);
                    CheckSuccess();
                    break;
                case Dir.RightSword:
                case Dir.Right:
                    PushRight(direction, position);
                    CheckSuccess();
                    break;
                default:
                    break;
            }
        }

        private void CheckSuccess()
        {
            for (int i = 0; i < baggage.Count; i++)
            {
                if (arrived.ElementAt(i) == false)
                {
                    return;
                }
            }
            blackHole = new BlackHole(new Vector2(5540, 12800));
            success = true;
        }

        private void PushLeft(Dir direction, Vector2 position)
        {
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                if (!BoxCollide(i, 2))
                {
                    i.PushLeft();
                    Check(i);
                }
            }
        }

        private bool BoxCollide(Baggage i, int command)
        {
            int FutureX = i.getFutureX(command);
            int FutureY = i.getFutureY(command);
            for (int x = 0; x < baggage.Count; x++)
            {
                int OtherBoxX = baggage.ElementAt(x).GetLocX();
                int OtherBoxY = baggage.ElementAt(x).GetLocY();
                if ((OtherBoxX == FutureX) && (OtherBoxY == FutureY))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DidCollide(Vector2 otherPos, int otherL, int otherW)
        {
            foreach (Baggage b in baggage)
            {
                if (b.Collide(otherPos,otherL,otherW))
                {
                    return true;
                }
            }
            return false;
        }

        private void PushRight(Dir direction, Vector2 position)
        {
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                if (!BoxCollide(i, 3))
                {
                    i.PushRight();
                    Check(i);
                }
            }
        }

        private void PushDown(Dir direction, Vector2 position)
        {
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                if (!BoxCollide(i, 1))
                {
                    i.PushDown();
                    Check(i);
                }
            }
        }

        public void PushUP(Dir direction, Vector2 position)
        {
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                if (!BoxCollide(i, 0))
                {
                    i.PushUp();
                    Check(i);
                }

            }
        }

        private Baggage Detect(Dir direction, Vector2 position)
        {
            Baggage ans;
            switch (direction)
            {
                case Dir.Up:
                    ans = DetectUp(direction, position);
                    break;
                case Dir.Down:
                    ans = DetectDown(direction, position);
                    break;
                case Dir.Left:
                    ans = DetectLeft(direction, position);
                    break;
                case Dir.Right:
                    ans = DetectRight(direction, position);
                    break;
                default:
                    ans = null;
                    break;
            }
            return ans;
        }

        private Baggage DetectRight(Dir direction, Vector2 position)
        {
            for (int i = 0; i < baggage.Count; i++)
            {
                int Dist = baggage.ElementAt(i).GetDistX(direction, position);
                if ((Dist <= 80) &&
                (Dist >= 0))
                {
                    return baggage.ElementAt(i);
                }
            }
            return null;
        }

        private Baggage DetectLeft(Dir direction, Vector2 position)
        {
            for (int i = 0; i < baggage.Count; i++)
            {
                int Dist = baggage.ElementAt(i).GetDistX(direction, position);
                if ((Dist >= -80) &&
                (Dist <= 0))
                {
                    return baggage.ElementAt(i);
                }
            }
            return null;
        }

        private Baggage DetectDown(Dir direction, Vector2 position)
        {
            for (int i = 0; i < baggage.Count; i++)
            {
                int Dist = baggage.ElementAt(i).GetDistY(direction, position);
                if ((Dist <= 80) &&
                (Dist >= 0))
                {
                    return baggage.ElementAt(i);
                }
            }
            return null;
        }

        private Baggage DetectUp(Dir direction, Vector2 position)
        {
            for (int i = 0; i < baggage.Count; i++)
                {
                    int Dist = baggage.ElementAt(i).GetDistY(direction, position);
                    if ((Dist >= -80) &&
                    (Dist <= 0))
                    {
                        return baggage.ElementAt(i);
                    }
                }
            return null;
        }

        //TODO On going
        private void Check(Baggage i)
        {
            bool IfNotArrived = true;
            for (int j = 0; j < dest.Count; j++)
            {
                if (CheckArrive(i, dest.ElementAt(j)))
                {
                    i.InformArrived();
                    IfNotArrived = false;
                    arrived[j] = true;
                }
            }
            if (IfNotArrived)
            {
                i.InformNotArrived();
            }
        }

        private bool CheckArrive(Baggage baggage, DestPoint destPoint)
        {
            int BaggageX = baggage.GetLocX();
            int BaggageY = baggage.GetLocY();
            int DestPointX = destPoint.getLocX();
            int DestPointY = destPoint.getLocY();
            if ((DestPointX >= BaggageX) && (DestPointX <= (BaggageX + blockWidth)) 
                && (DestPointY >= BaggageY) && (DestPointY <= (BaggageY + blockHeight)))
            {
                return true;
            }
            return false;
        }

        public void BlackDraw()
        {
            if (success)
            {
                spriteBatch.Draw(blackHoleSprite, new Vector2(blackHole.Position.X - 30, blackHole.Position.Y - 30), Color.White);
            }
        }
    }
}

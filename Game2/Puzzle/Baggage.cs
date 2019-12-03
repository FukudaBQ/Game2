using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Puzzle
{
    public class Baggage
    {
        public int a = 9;
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int width = 37;
        private int height = 51;
        private int locationX;
        private int locationY;
        private int sourceX = 45;
        private int sourceY = 0;
        private int blockWidth = 80;
        private int blockHeight = 80;
        private int offsetX = 0;
        private int offsetY = 0;
        private int upLimit;
        private int downLimit;
        private int leftLimit;
        private int rightLimit;
        public Baggage(Texture2D texture, SpriteBatch spriteBatch, int X, int Y, int upLimit, int downLimit, int leftLimit, int rightLimit)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.locationX = X;
            this.locationY = Y;
            this.upLimit = upLimit;
            this.downLimit = downLimit;
            this.leftLimit = leftLimit;
            this.rightLimit = rightLimit;
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(sourceX, sourceY, width, height);
            Rectangle destinationRectangle = new Rectangle(locationX +
                offsetX * blockWidth, locationY + offsetY * blockHeight, blockWidth, blockHeight);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void PushUp()
        {
            int Command = 0;
            if (Precheck(Command))
            {
                offsetY--;
            }
        }

        public void PushDown()
        {
            int Command = 1;
            if (Precheck(Command))
            {
                offsetY++;
            }
        }

        public void PushLeft()
        {
            int Command = 2;
            if (Precheck(Command))
            {
                offsetX--;
            }
        }
        public void PushRight()
        {
            int Command = 3;
            if (Precheck(Command))
            {
                offsetX++;
            }
        }

        private bool Precheck(int command)
        {
            int CurrentX = locationX + offsetX * blockWidth;
            int CurrentY = locationY + offsetY * blockHeight;
            if ((command < 2) && (CurrentY > upLimit) && ((CurrentY + blockHeight) < downLimit))
            {
                return true;
            }
            if ((command >= 2) && (CurrentX > leftLimit) && ((CurrentX + blockWidth) < rightLimit))
            {
                return true;
            }
            return false;
        }


        //baggage - player, baggage downer as positive
        public int GetDistY(Dir direction, Vector2 position)
        {
            int CurrentLoc = locationY + offsetY * blockHeight;
            if ((position.X >= (locationX + offsetX * blockWidth) - 5) &&
                (position.X <= (locationX + offsetX * blockWidth + blockWidth) + 5))
            {
                if (CurrentLoc > position.Y)
                {
                    return CurrentLoc - (int)position.Y;
                }
                else
                {
                    return CurrentLoc + blockHeight - (int)position.Y;
                }
            }
            return 1024;
        }
        public int GetDistX(Dir direction, Vector2 position)
        {
            int CurrentLoc = locationX + offsetX * blockHeight;
            if ((position.Y >= (locationY + offsetY * blockWidth) - 5) &&
                (position.Y <= (locationY + offsetY * blockWidth + blockWidth) + 5))
            {
                if (CurrentLoc > position.X)
                {
                    return CurrentLoc - (int)position.X;
                }
                else
                {
                    return CurrentLoc + blockHeight - (int)position.X;
                }
            }
            return 1024;
        }

        public void InformArrived()
        {
            sourceX = 89;
        }

        public int GetLocX()
        {
            return locationX + offsetX * blockWidth;
        }

        public int GetLocY()
        {
            return locationY + offsetY * blockHeight;
        }

        public void InformNotArrived()
        {
            sourceX = 45;
        }

        public bool Collide(Vector2 otherPos, int otherL, int otherW)
        {
            int CurrentX = locationX + offsetX * blockHeight;
            int CurrentY = locationY + offsetY * blockHeight;
            int SmallOffset = 20;
            //TODO
            if (Math.Abs(CurrentX - otherPos.X) <= (blockHeight - SmallOffset) && Math.Abs(CurrentY - otherPos.Y) <= (blockWidth - SmallOffset))
            {
                return true;
            }
            return false;
        }

        public int getFutureX(int command)
        {
            if (command == 2)
            {
                return locationX + offsetX * blockWidth - blockWidth;
            }
            else if (command == 3)
            {
                return locationX + offsetX * blockWidth + blockWidth;
            }
            else
            {
                return locationX + offsetX * blockWidth;
            }
        }

        public int getFutureY(int command)
        {
            if (command == 0)
            {
                return locationY + offsetY * blockHeight - blockHeight;
            }
            else if (command == 1)
            {
                return locationY + offsetY * blockHeight + blockHeight;
            }
            else
            {
                return locationY + offsetY * blockHeight;
            }
        }
    }
    
}

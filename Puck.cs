using System;
namespace Pong
{
    public class Puck
    {
        private int xPos, yPos;
        private char shape;

        public Puck()
        {
            this.xPos = 0;
            this.yPos = 0;
            this.shape = 'o';
        }

		public int XPos
		{
			get
			{
				return this.xPos;
			}
			set
			{
				this.xPos = value;
			}
		}

		public int YPos
		{
			get
			{
				return this.yPos;
			}
			set
			{
				this.yPos = value;
			}
		}

		public char Shape
		{
			get
			{
                return this.shape;
			}
		}

    }
}

using System;
namespace Pong
{
    class Handle
    {
        private int xPos, yPos;
        private int height, width;
        private char shape;

        public Handle(char shape){
            this.height = 3;
            this.width = 1;
            this.shape = shape;
        }

        public int XPos {
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

		public int Height
		{
			get
			{
                return this.height;
			}
		}

		public int Width
		{
			get
			{
                return this.width;
			}
		}


		public char Shape
		{
			get
			{
                return this.shape;
			}
			set
			{
				this.shape = value;
			}
		}
    }
}

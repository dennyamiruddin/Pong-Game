using System;
namespace Pong
{
   
	class Border
	{

		private char[,] frame;
		private int width, height;
		private char wall, background;

		public Border(char wall, char background, int width, int height)
		{
			this.width = width;
			this.height = height;
			this.wall = wall;
			this.background = background;
			this.frame = new char[this.width, this.height];
		}

		public void print()
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					Console.Write(frame[x, y]);
				}
				Console.WriteLine();
			}
		}

		// frame , width , height , border , background
		public int Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		public int Height
		{
			get
			{
				return this.height;
			}
			set
			{
				this.height = value;
			}
		}

		public char Wall
		{
			get
			{
				return this.wall;
			}
			set
			{
				this.wall = value;
			}
		}

		public char Background
		{
			get
			{
				return this.background;
			}
			set
			{
				this.background = value;
			}
		}
	}
}

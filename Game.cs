using System;
using System.Threading;
namespace Pong
	// This game is very good, and i love it
{
    public class Game
    {

		private char[,] world;
		private Border border;
		private Puck puck;
        	private int xSpeed;

        // Handle object
        private Handle handle1, handle2;
        private int[] handle1Y, handle2Y;

        private bool gameOver;
        private int xDirection, yDirection;
        private const int
        up = 1,
        down = 2,
        right = 3,
        left = 4;

        private Random rand;
        private int p1Score, p2Score;

        ConsoleKeyInfo key, defaultKey;

        public Game()
        {
            setup();
            while (!this.gameOver){
                if (!Console.KeyAvailable){
                    control(defaultKey);
					direction(xDirection, yDirection);
					logic();
					update();
					draw();
					Thread.Sleep(75);
                }
                else{
                    key = Console.ReadKey(true);
                    control(key);
                }
            }

		}

        public void setup(){
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            // random number generator
            rand = new Random();

            border = new Border('X', ' ', 80, 22);
            puck = new Puck();

            // handle object
            handle1 = new Handle('▌');
            handle2 = new Handle('▌');

            // setting up handle point
            handle1.XPos = 2;
            handle1.YPos = border.Height / 2;
            handle2.XPos = border.Width - 2;
            handle2.YPos = border.Height / 2;

            handle1Y = new int[handle1.Height];
			handle2Y = new int[handle2.Height];

            // first index value
            handle1Y[0] = handle1.YPos -1;
            handle2Y[0] = handle2.YPos - 1;

            // second index value
            handle1Y[1] = handle1.YPos;
            handle2Y[1] = handle2.YPos;

			// third index value
			handle1Y[2] = handle1.YPos + 1;
            handle2Y[2] = handle2.YPos + 1;
       

            world = new char[border.Width, border.Height];
            gameOver = false;
            p1Score = 0;
            p2Score = 0;

            // puck initial position
            puck.XPos = border.Width / 2;
            puck.YPos = border.Height / 2;

            // puck initial direction
            xDirection = left;
			//yDirection = up;

            // puck initial speed
            xSpeed = 1;

            // defult key
            defaultKey = new ConsoleKeyInfo('D', ConsoleKey.D, false, false, false);
        }

        public void control(ConsoleKeyInfo key){

            // Handle 1 control
            if (key.Key == ConsoleKey.A){
                handle1.YPos--;
				handle1Y[0] = handle1.YPos - 1;
                handle1Y[1] = handle1.YPos;
                handle1Y[2] = handle1.YPos + 1;
			}
            if (key.Key == ConsoleKey.Z){
                handle1.YPos++;
				handle1Y[0] = handle1.YPos - 1;
				handle1Y[1] = handle1.YPos;
				handle1Y[2] = handle1.YPos + 1;
            }

			// Handle 2 control
			if (key.Key == ConsoleKey.UpArrow)
			{
				handle2.YPos--;
				handle2Y[0] = handle2.YPos - 1;
				handle2Y[1] = handle2.YPos;
				handle2Y[2] = handle2.YPos + 1;
			}
			if (key.Key == ConsoleKey.DownArrow)
			{
				handle2.YPos++;
				handle2Y[0] = handle2.YPos - 1;
				handle2Y[1] = handle2.YPos;
				handle2Y[2] = handle2.YPos + 1;
			}

			if (key.Key == ConsoleKey.D)
			{
				// Do not do anything 
			}
        }

        public void direction(int xDirection, int yDirection){
            
            if (yDirection == up){
                puck.YPos--;
            }
            if (yDirection == down){
                puck.YPos++;
            }
            if (xDirection == right)
			{
                puck.XPos = puck.XPos + xSpeed;
			}
            if (xDirection == left)
            {
                puck.XPos = puck.XPos - xSpeed;
            }
        }

        public void logic(){
            
			// Puck hit top wall
			if (puck.YPos < 2)
			{
                // direction change to y++
                yDirection = down;
			}

			// puck hit left wall
			if (puck.XPos < 1)
			{
                // handle 2 wins one point
                p2Score++;
				// puck new position
				puck.XPos = border.Width / 2;
				puck.YPos = border.Height / 2;

				// puck new direction
				xDirection = right;
                yDirection = 0;

				// puck new speed
				xSpeed = 1;
			}

			// Puck hit bottom wall
			if (puck.YPos > border.Height - 3)
			{
                // direction change to y--
                yDirection = up;
			}

			// puck hit right wall
			if (puck.XPos > border.Width - 2)
			{
                // handle 1 wins one point
				p1Score++;
				// puck new position
				puck.XPos = border.Width / 2;
				puck.YPos = border.Height / 2;

                // puck new direction
                xDirection = left;
                yDirection = 0;

				// puck new speed
				xSpeed = 1;
			}

            // Handle 1 wall logic
            // Top wall
            if (handle1Y[0] < 1)
            {
				handle1.YPos++;
				handle1Y[0] = handle1.YPos - 1;
				handle1Y[1] = handle1.YPos;
				handle1Y[2] = handle1.YPos + 1;
            }

			// Bottom wall
            if (handle1Y[2] > border.Height - 2)
			{
				handle1.YPos--;
				handle1Y[0] = handle1.YPos - 1;
				handle1Y[1] = handle1.YPos;
				handle1Y[2] = handle1.YPos + 1;
			}

            // Handle 2 wall logic
            // Top wall
            if (handle2Y[0] < 1)
            {
                handle2.YPos++;
                handle2Y[0] = handle2.YPos - 1;
                handle2Y[1] = handle2.YPos;
                handle2Y[2] = handle2.YPos + 1;
            }

            // Bottom wall
            if (handle2Y[2] > border.Height - 2)
            {
                handle2.YPos--;
                handle2Y[0] = handle2.YPos - 1;
                handle2Y[1] = handle2.YPos;
                handle2Y[2] = handle2.YPos + 1;
            }

            // Puck hit handle 1
            // top
            if (puck.XPos == handle1.XPos + 1 && puck.YPos == handle1Y[0])
            {
				// puck new direction
                xDirection = right;
                yDirection = up;
                xSpeed = rand.Next(1, 3);
            }

			//middle
			if (puck.XPos == handle1.XPos + 1 && puck.YPos == handle1Y[1])
			{
				// puck new direction
				xDirection = right;
				yDirection = 0;
				xSpeed = rand.Next(1, 3);
			}

            // bottom
            if (puck.XPos == handle1.XPos + 1 && puck.YPos == handle1Y[2])
            {
				// puck new direction
				xDirection = right;
				yDirection = down;
                xSpeed = rand.Next(1, 3);
            }

			// Puck hit handle 2
			// top
			if (puck.XPos == handle2.XPos - 1 && puck.YPos == handle2Y[0])
			{
				// puck new direction
				xDirection = left;
				yDirection = up;
				xSpeed = rand.Next(1, 3);
			}

			//middle
			if (puck.XPos == handle2.XPos - 1 && puck.YPos == handle2Y[1])
			{
				// puck new direction
				xDirection = left;
				yDirection = 0;
				xSpeed = rand.Next(1, 3);
			}

			// bottom
			if (puck.XPos == handle2.XPos - 1 && puck.YPos == handle2Y[2])
			{
				// puck new direction
				xDirection = left;
				yDirection = down;
				xSpeed = rand.Next(1, 3);
			}

            // gameover
            if (p1Score >= 10 || p2Score >= 10){
                gameOver = true;
            }
        }


        public void update(){
			for (int y = 0; y < border.Height; y++)
			{
                for (int x = 0; x < border.Width; x++)
                {
                    // Top wall
                    if (y == 0 && x >= 0)
                    {
                        world[x, y] = border.Wall;
                    }

                    // Left wall
                    else if (y >= 0 && x == 0)
                    {
                        world[x, y] = border.Wall;
                    }

                    // Bottom wall
                    else if (y == border.Height - 1 && x >= 0)
                    {
                        world[x, y] = border.Wall;
                    }

                    // Right wall
                    else if (y >= 0 && x == border.Width - 1)
                    {
                        world[x, y] = border.Wall;
                    }


                    // Draw Puck
                    else if (y == puck.YPos && x == puck.XPos)
                    {
                        world[x, y] = puck.Shape;
                    }


                    // Background
                    else
                    {
                        world[x, y] = border.Background;
                    }

                    // Draw Handle 1
                    for (int i = 0; i < handle1.Height; i++)
                    {
                        world[handle1.XPos, handle1Y[i]] = handle1.Shape;
                    }

					// Draw handle 2
					for (int i = 0; i < handle2.Height; i++)
					{
						world[handle2.XPos, handle2Y[i]] = handle2.Shape;
                    }
				}
			}
        }

        public void draw(){
			Console.Clear();
			for (int y = 0; y < border.Height; y++)
			{
				for (int x = 0; x < border.Width; x++)
				{
					Console.Write(world[x, y]);
				}
				Console.WriteLine();
			}
            Console.Write(" Player 1: " + p1Score +
                          "\t\t\t\t\t\t\t    Player 2: " + p2Score);
        }
    }
}

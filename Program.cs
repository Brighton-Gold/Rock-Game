using Raylib_cs;
using System.Numerics;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            var Objects = new List<Rock>();


            var ScreenHeight = 500;
            var ScreenWidth = 1000;
            float BallRadius = 15;
            var BallPosition = new Vector2(ScreenWidth / 2, ScreenHeight - BallRadius);
            var BallMovementSpeed = 4;
            var loopcount = 0;

            PlayerBall playerball = new PlayerBall(10);

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Rock Game");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose() && playerball.CurrentPoints >= 1) // game loop runs while esc or close button is not hit AND if the player's score is 1 or more. 
            {

                if (loopcount < 100)
                {
                    Raylib.DrawText("Move the ball with the arrow keys!", 12, 12, 20, Color.BLACK);
                }
                else if (100 < loopcount && loopcount < 200)
                {
                    Raylib.DrawText("Collect the gems, avoid the rocks!", 12, 12, 20, Color.BLACK);
                }
                else if (200 < loopcount && loopcount < 300)
                {
                    Raylib.DrawText("Dont Die!", 12, 12, 20, Color.BLACK);
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText($"{Objects.Count()}", 12, 30, 20, Color.BLACK);

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    BallPosition.X += BallMovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    BallPosition.X -= BallMovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    BallPosition.Y -= BallMovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    BallPosition.Y += BallMovementSpeed;
                }


                Raylib.DrawCircleV(BallPosition, BallRadius, Color.MAROON);



                if (loopcount == 200)
                {
                    Rock rock = new Rock(ScreenWidth);

                    Objects.Add(rock);

                    loopcount = 0;

                }
                loopcount += 1;

                for (int i = 0; i < Objects.Count(); i++)
                {
                    Raylib.DrawCircleV(Objects[i].Position, BallRadius, Color.GREEN);
                    Objects[i].Move();

                    if (BallPosition == Objects[i].Position)
                    {
                        Raylib.EndDrawing();

                        Objects.Remove(Objects[i]);

                    }

                }
                Raylib.EndDrawing();


            }

            Raylib.CloseWindow();
        }

    }
}

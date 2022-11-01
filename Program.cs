using Raylib_cs;
using System.Numerics;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {

            var ScreenHeight = 900;
            var ScreenWidth = 1500;
            float BallRadius = 15;
            var BallPosition = new Vector2(ScreenHeight / 2, ScreenWidth - BallRadius);
            var BallMovementSpeed = 4;

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Ball");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Raylib.DrawText("Move the ball with the arrow keys!", 12, 12, 20, Color.WHITE);

                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) {
                    BallPosition.X += BallMovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) {
                    BallPosition.X -= BallMovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP)) {
                    BallPosition.Y -= BallMovementSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN)) {
                    BallPosition.Y  += BallMovementSpeed;
                }

                
                Raylib.DrawCircleV(BallPosition, BallRadius, Color.MAROON);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}

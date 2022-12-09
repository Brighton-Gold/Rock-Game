using Raylib_cs;
using System.Numerics;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            var Objects = new List<Rock>();
            var GemList = new List<Gem>();

            int points = 0;
            var ScreenHeight = 500;
            var ScreenWidth = 1000;
            float BallRadius = 15;
            var BallPosition = new Vector2(ScreenWidth / 2, ScreenHeight - BallRadius);
            var BallMovementSpeed = 4;
            var loopcount = 0;

            PlayerBall playerball = new PlayerBall(10);

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Rock Game");
            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose() && points >= -1) // game loop runs while esc or close button is not hit AND if the player's score is 1 or more. 
            {

                if (loopcount < 100)
                {
                    Raylib.DrawText("Move the ball with the arrow keys!", 12, 12, 20, Color.BLACK);
                }
                else if (100 < loopcount && loopcount < 200)
                {
                    Raylib.DrawText("Collect the gems(Pink), avoid the rocks(Brown)!", 12, 12, 20, Color.BLACK);
                }
                else if (200 < loopcount && loopcount < 300)
                {
                    Raylib.DrawText("Dont Die!", 12, 12, 20, Color.BLACK);
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawText($"Score {points}", 12, 30, 20, Color.BLACK);

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


                if (loopcount == 150)
                {
                    Gem gem = new Gem(ScreenWidth);
                    GemList.Add(gem);

                }
                for (int item = 0; item < GemList.Count(); item++)
                {
                    Raylib.DrawCircleV(GemList[item].Position, BallRadius, Color.PINK);
                    GemList[item].Move();

                    if (Raylib.CheckCollisionCircles(BallPosition, BallRadius, GemList[item].Position, BallRadius) == true)        // Check collision between two circles

                    {

                        points = GemList[item].EditPoints(points);
                        Raylib.EndDrawing();

                        GemList.Remove(GemList[item]);

                    }
                }

                if (loopcount == 200)
                {
                    Rock rock = new Rock(ScreenWidth);

                    Objects.Add(rock);

                    loopcount = 0;

                }
                loopcount += 1;

                for (int i = 0; i < Objects.Count(); i++)
                {
                    Raylib.DrawCircleV(Objects[i].Position, BallRadius, Color.BROWN);
                    Objects[i].Move();

                    if (Raylib.CheckCollisionCircles(BallPosition, BallRadius, Objects[i].Position, BallRadius) == true)        // Check collision between two circles

                    {

                        points = Objects[i].EditPoints(points);
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

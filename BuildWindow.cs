using Raylib_cs;
using System.Numerics;

class Window 
{
    int ScreenHeight = 900;
    int ScreenWidth = 1500;
                
    Raylib.InitWindow(ScreenWidth, ScreenHeight, "Ball");
    Raylib.SetTargetFPS(60);

    while (!Raylib.WindowShouldClose())
    {
        Raylib.ClearBackground(Color.BLACK);
    }
    Raylib.CloseWindow();
}
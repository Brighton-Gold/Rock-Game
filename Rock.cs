using Raylib_cs;
using System.Numerics;

class Rock
{
    // This should draw a rock at a random position along the top of the screen
    public static void DrawRock(int ScreenHeight, int ScreenWidth) 
    {
        // Calling Random to make the horrizontal position of the rock random
        Random Rndint = new Random();
        // getting a new Ballposition object for use in the DrawCircleV Method for the rock
        var BallPosition = new Vector2(ScreenHeight, Rndint.Next(ScreenWidth)); // this uses the screen height to start it on the top of the screen
        // Draws a beige rock at the determined position (above) and 8 pixels in size
        Raylib.DrawCircleV(BallPosition, 8, Color.BEIGE);
    }
}
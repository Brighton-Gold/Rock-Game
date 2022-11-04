using Raylib_cs;
using System.Numerics;

class Rock
{
    // This should draw a rock at a random position along the top of the screen
    public static void DrawRock(int ScreenWidth) 
    {
        // Calling Random to make the horrizontal position of the rock random
        Random Rndint = new Random();
        // getting a new Ballposition object for use in the DrawCircleV Method for the rock
        var BallPosition = new Vector2(Rndint.Next(ScreenWidth), 0); // this uses the screen height to start it on the top of the screen
        // Draws a beige rock at the determined position (above) and 8 pixels in size
        Raylib.DrawCircleV(BallPosition, 8, Color.BEIGE);
    }
    
    public virtual int EditPoints(int CurrentPoints) // Virtual so it can be changed in Gem()
    {
        return CurrentPoints -= 1; // changes and returns the player's current points
    }


}


class Gem : Rock // Basically the same as the Rock class, so this uses inheritance from Rock(). 
{

    public override int EditPoints(int CurrentPoints)
    {
        return CurrentPoints += 1;
    }
}

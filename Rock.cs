using Raylib_cs;
using System.Numerics;

class Rock
{
    // This should draw a rock at a random position along the top of the screen
    public Vector2 Position;
    public Rock(int ScreenWidth)
    {
        Vector2 rockspot = CreateNewRock(ScreenWidth);
        Position = rockspot;

    }

    public Vector2 CreateNewRock(int ScreenWidth)
    {
        // Calling Random to make the horrizontal position of the rock random
        Random random = new Random();
        int Rndint = random.Next(0, ScreenWidth);
        // getting a new Ballposition object for use in the DrawCircleV Method for the rock
        var RockPosition = new Vector2(Rndint, 0); // this uses the screen height to start it on the top of the screen

        return RockPosition;


    }
    public Vector2 Move()
    {
        Vector2 Velocity = new Vector2(0, 1);
        Vector2 NewPosition = Position;
        NewPosition.Y += Velocity.Y;
        Position = NewPosition;

        return Position;

    }

    public virtual int EditPoints(int CurrentPoints) // Virtual so it can be changed in Gem()
    {
        return CurrentPoints -= 1; // changes and returns the player's current points
    }


}


// class Gem : Rock // Basically the same as the Rock class, so this uses inheritance from Rock(). 
// {

//     public override int EditPoints(int CurrentPoints)
//     {
//         return CurrentPoints += 1;
//     }
// }

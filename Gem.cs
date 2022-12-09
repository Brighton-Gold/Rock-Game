using Raylib_cs;
using System.Numerics;

class Gem : Rock
{
    public Gem(int ScreenWidth): base(ScreenWidth)
    {

    }
    public override int EditPoints(int CurrentPoints) // Virtual so it can be changed in Gem()
    {
        return CurrentPoints += 1; // changes and returns the player's current points
    }


    // Basically the same as the Rock class, so this can use inheritance from Rock(). 
}

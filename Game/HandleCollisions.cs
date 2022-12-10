using Raylib_cs;
using System.Numerics;

public class HandleCollisions
{
    public HandleCollisions()
    {
    }

    public bool HandlePlayerPlatform(Player player, Platform platform)
    {
        if (Raylib.CheckCollisionRecs(player.GetRectangle(), platform.GetRectangle()) 
            && player.GetVelocity().GetY() > 0 
           )
        {
            player.SetPosition(new Point(player.GetPosition().GetX(), platform.GetPosition().GetY() - 49));
            player.SetAirborne(false);
            return false;
        }
        else
        {
            player.SetAirborne(true);
            return true;
        }
    }

    public bool HandlePlayerCollectable(Player player, Collectable collectable)
    {
        return Raylib.CheckCollisionCircleRec(new Vector2(collectable.GetPosition().GetX(), 
            collectable.GetPosition().GetY()), collectable.GetRadius(), player.GetRectangle());
    }
}
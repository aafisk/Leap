using Raylib_cs;
using Constant;

public class Player: Actor
{
    private int width = 50;
    private int height = 50;
    private bool airborne = false;
    private Rectangle rec = new Rectangle(0, 0, 0, 0);

    public Player(Point StartLocation, Color color)
    {
        SetPosition(StartLocation);
        SetColor(color);
        
    }

    public override void SetPosition(Point position)
    {
        if (position == null)
        {
            throw new ArgumentException("position can't be null");
        }

        if (position.GetX() > Constants.MAX_X - 43)
        {
            this.position = new Point(Constants.MAX_X - 50, GetPosition().GetY());
        }
        else if (position.GetX() < -7)
        {
            this.position = new Point(0, GetPosition().GetY());
        }

        else
        {
            this.position = position;
        }
    }

    public override void DrawActor()
    {
        // rec = new Rectangle(GetPosition().GetX(), GetPosition().GetY(), width, height);
        // Raylib.DrawRectangle(GetPosition().GetX(), GetPosition().GetY(), width, height, GetColor().ToRaylibColor());
        rec = new Rectangle(GetPosition().GetX(), GetPosition().GetY(), width, height);
        Raylib.DrawRectangleRec(rec, GetColor().ToRaylibColor());
    }

    public void SetAirborne(bool InAir)
    {
        airborne = InAir;
    }

    public bool IsAirborne()
    {
        return airborne;
    }

    public Rectangle GetRectangle()
    {
        return rec;
    }
}
using Raylib_cs;

public class Collectable: Actor
{
    private int radius = 10;
    private bool collected = false;
    private int value = 0;

    public Collectable(Point StartLocation, int PointValue, Color color)
    {
        SetPosition(StartLocation);
        SetColor(color);
        value = PointValue;
    }

    public override void DrawActor()
    {
        Raylib.DrawCircle(GetPosition().GetX(), GetPosition().GetY(), radius, GetColor().ToRaylibColor());
    }

    public int GetRadius()
    {
        return radius;
    }

    public bool GetCollected()
    {
        return collected;
    }

    public void SetCollected(bool value)
    {
        collected = value;
    }

    public int GetValue()
    {
        return value;
    }
}
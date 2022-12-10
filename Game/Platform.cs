using Raylib_cs;
using Constant;

public class Platform: Actor
{
    public int width = 0;
    public int height = 0;
    private Rectangle rec = new Rectangle(0, 0, 0, 0);

    public Platform(Point TopLeft, int width, int height, Color color)
    {
        this.SetPosition(TopLeft);
        this.width = width;
        this.height = height;
        this.SetColor(color);
    }

    public override void DrawActor()
    {
        // Raylib.DrawRectangle(GetPosition().GetX(), GetPosition().GetY(), width, height, this.GetColor().ToRaylibColor());
        // rec = new Rectangle(this.GetPosition().GetX(), this.GetPosition().GetY(), width, height);
        rec = new Rectangle(GetPosition().GetX(), GetPosition().GetY(), width, height);
        Raylib.DrawRectangleRec(rec, GetColor().ToRaylibColor());
    }

    public Rectangle GetRectangle()
    {
        return rec;
    }
}
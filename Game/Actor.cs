using Raylib_cs;
using Constant;

public class Actor 
{
    private Point position = new Point(0, 0);
    private Point velocity = new Point(0, 0);
    private Color color = Constants.WHITE;

    public Actor()
    {
    }

    /// Get and set position.
    public Point GetPosition()
    {
        return position;
    }

    public void SetPosition(Point position)
    {
        if (position == null)
        {
            throw new ArgumentException("position can't be null");
        }
        this.position = position;
    }

    /// Get and set velocity.
    public Point GetVelocity()
    {
        return velocity;
    }

    public void SetVelocity(Point velocity)
    {
        if (velocity == null)
        {
            throw new ArgumentException("velocity can't be null");
        }
        this.velocity = velocity;
    }

    /// Get and set color
    public Color GetColor()
    {
        return color;
    }

    public void SetColor(Color color)
    {
        if (color == null)
        {
            throw new ArgumentException("color can't be null");
        }
        this.color = color;
    }

    public virtual void DrawActor()
    {

    }
}
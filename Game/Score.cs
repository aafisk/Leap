using Raylib_cs;

public class Score: Actor
{
    private int score = 0;
    private string player = "";
    private string text = "";

    public Score(Point Position, string hud, Color color)
    {
        SetPosition(Position);
        player = hud;
        text = String.Format("{0}: {1}", player, score);
        SetColor(color);
    }

    public void UpdateScore(int points)
    {
        score += points;
        text = String.Format("{0}: {1}", player, score);
    }

    public override void DrawActor()
    {
        Raylib.DrawText(text, GetPosition().GetX(), GetPosition().GetY(), 20, GetColor().ToRaylibColor());
    }
}
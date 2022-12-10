using Raylib_cs;

public class Timer: Actor
{
    private float lifeTime;

    public Timer(float time, Point Position)
    {
        lifeTime = time;
        SetPosition(Position);
    }

    public void StartTimer(float lifetime)
    {
        //startTime = Raylib.GetTime();
        lifeTime = lifetime;
    }

    public void UpdateTimer()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Raylib.GetFrameTime();
        }
    }

    public bool TimerDone()
    {
        if (lifeTime < 0)
        {
            lifeTime = 0;
        }
        return lifeTime == 0;
    }

    public override void DrawActor()
    {
        Raylib.DrawText(String.Format("Time: {0:.###}", lifeTime), GetPosition().GetX(), GetPosition().GetY(), 20, GetColor().ToRaylibColor());
    }
}

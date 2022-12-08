using Raylib_cs;
using Constant;
class Game {

    private bool GameOver = false;
    private List<Platform> platforms = new List<Platform>();

    public Game() {

    }

    public void Play() {
        Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, "Leap");
        Raylib.SetTargetFPS(60);

        Platform TopLeft = new Platform(new Point(300, 200), 50, 20, Constants.GREEN);
        platforms.Add(TopLeft);


        while(!GameOver)
        {
            foreach(Platform platform in platforms)
            {
                platform.DrawActor();
            }
        }

        Raylib.CloseWindow();
    }
}
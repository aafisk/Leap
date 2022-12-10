using Raylib_cs;
using Constant;
class Game {

    private List<Platform> platforms = new List<Platform>();
    private List<Collectable> collectables = new List<Collectable>();
    private Random random = new Random();
    private bool GameOver = false;

    public Game() {

    }

    public void Play() {
        Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, "Leap");
        Raylib.SetTargetFPS(60);

        // Create platforms and add them to an array.
        Platform TopLeft = new Platform(new Point(0, 200), 250, 20, Constants.GREEN);
        platforms.Add(TopLeft);
        Platform TopRight = new Platform(new Point(Constants.MAX_X - 250, 200), 250, 20, Constants.GREEN);
        platforms.Add(TopRight);
        Platform Middle = new Platform(new Point(Constants.MAX_X / 2 - 100, 300), 200, 20, Constants.GREEN);
        platforms.Add(Middle);
        Platform Ground = new Platform(new Point(0, Constants.MAX_Y - 200), Constants.MAX_X, 200, Constants.GREEN);
        platforms.Add(Ground);

        // Create player objects
        Player Player1 = new Player(new Point(100, Constants.MAX_Y - 249), Constants.RED);
        Player Player2 = new Player(new Point(Constants.MAX_X - 150, Constants.MAX_Y - 249), Constants.ORANGE);

        // Create score objects
        Score Score1 = new Score(new Point(30, 15), "Player 1", Constants.RED); // insert color here
        Score Score2 = new Score(new Point(Constants.MAX_X - 175, 15), "Player 2", Constants.ORANGE);

        Timer Timer = new Timer(60, new Point(Constants.MAX_X / 2 - 75, 15));

        MoveActors moveActors = new MoveActors(Player1, Player2);
        HandleCollisions handleCollisions = new HandleCollisions();

        while(!Raylib.WindowShouldClose())
        {
            /// Draw actors to the screen.
            Raylib.BeginDrawing();
            Raylib.ClearBackground((Constants.BLUE).ToRaylibColor());

            foreach(Platform platform in platforms)
            {
                platform.DrawActor();
            }
            
            foreach(Collectable collectable in collectables)
            {
                collectable.DrawActor();
            }

            Player1.DrawActor();
            Player2.DrawActor();

            Score1.DrawActor();
            Score2.DrawActor();

            Timer.DrawActor();

            Raylib.EndDrawing();

            if (GameOver) {
                Score1.SetPosition(new Point(130, Constants.MAX_Y / 2));
                Score2.SetPosition(new Point(Constants.MAX_X - 275, Constants.MAX_Y / 2));
            }
            
            // Update player location
            moveActors.Execute();

            // Handle collisions
            // Player and platform
            foreach(Platform platform in platforms)
            {
                if (!handleCollisions.HandlePlayerPlatform(Player1, platform))
                {
                    break;
                }
            }

            foreach(Platform platform in platforms)
            {
                if (!handleCollisions.HandlePlayerPlatform(Player2, platform))
                {
                    break;
                }
            }

            if (!GameOver)
            {
                Timer.UpdateTimer();
                if (Timer.TimerDone()) 
                {
                    GameOver = true;
                }

                // Player and collectable
                int iRemove1 = 0;
                int iRemove2 = 0;
                bool remove1 = false;
                bool remove2 = false;

                foreach(Collectable collectable in collectables)
                {
                    if (handleCollisions.HandlePlayerCollectable(Player1, collectable))
                    {
                        iRemove1 = collectables.IndexOf(collectable);
                        remove1 = true;
                        collectable.SetCollected(true);
                        Score1.UpdateScore(collectable.GetValue());
                    }
                }

                foreach(Collectable collectable in collectables)
                {
                    if (handleCollisions.HandlePlayerCollectable(Player2, collectable))
                    {
                        iRemove2 = collectables.IndexOf(collectable);
                        remove2 = true;
                        collectable.SetCollected(true);
                        Score2.UpdateScore(collectable.GetValue());
                    }
                }

                if (remove1)
                {
                    if (collectables[iRemove1].GetCollected())
                    {
                        collectables.RemoveAt(iRemove1);
                    }
                }

                if (remove2)
                {
                    if (collectables[iRemove2].GetCollected())
                    {
                        collectables.RemoveAt(iRemove2);
                    }
                }

                // Generate new collectables
                int value = random.Next(1, 151);
                if (value >= 1 && value <= 3)
                {
                    int X = random.Next(10, Constants.MAX_X - 10);
                    int Y = random.Next(25, Constants.MAX_Y - 215);
                    Color color = Constants.YELLOW;
                    if (value == 2)
                    {
                        color = Constants.LIGHT_ORANGE;
                    }
                    if (value == 3)
                    {
                        color = Constants.LIGHT_RED;
                    }
                    Collectable collectable = new Collectable(new Point(X, Y), value, color);
                    collectables.Add(collectable);
                }
            }
        }

        Raylib.CloseWindow();
    }
}
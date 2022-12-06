using Raylib_cs;
using CSE-210-Leap;

class Game {

    public Game() {

    }

    public void Play() {
        Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, "Leap");
        Raylib.SetTargetFPS(60);

        Raylib.CloseWindow();
    }
}
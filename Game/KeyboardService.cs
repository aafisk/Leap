using Raylib_cs;

namespace Keyboard
{
    /// <summary>
    /// <para>Detects player input.</para>
    /// <para>
    /// The responsibility of a KeyboardService is to indicate whether or not a key is up or down.
    /// </para>
    /// </summary>
    public class KeyboardService
    {
        private Dictionary<string, KeyboardKey> keys
                = new Dictionary<string, KeyboardKey>();

        /// <summary>
        /// Constructs a new instance of KeyboardService using the given cell size.
        /// </summary>
        public KeyboardService()
        {
            // P 1 Controls
            keys["w"] = KeyboardKey.KEY_W;
            keys["a"] = KeyboardKey.KEY_A;
            keys["d"] = KeyboardKey.KEY_D;

            // P 2 controls
            keys["up"] = KeyboardKey.KEY_UP;
            keys["left"] = KeyboardKey.KEY_LEFT;
            keys["right"] = KeyboardKey.KEY_RIGHT;

            // Unused keys
            // keys["s"] = KeyboardKey.KEY_S;
            // keys["down"] = KeyboardKey.KEY_DOWN;
        }

        public bool IsKeyDown(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyDown(raylibKey);
        }

        public bool IsKeyUp(string key)
        {
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyUp(raylibKey);
        }
    }
}
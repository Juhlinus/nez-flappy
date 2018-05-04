using Nez;
using static Nez.Scene;

namespace FlappyFlop
{
    public class Game1 : Core
    {
        public static int designHeight = 288;
        public static int designWidth = 512;
        public Game1() { }

        protected override void Initialize()
        {
            base.Initialize();

            Nez.Console.DebugConsole.consoleKey = Microsoft.Xna.Framework.Input.Keys.F2;

            setDefaultDesignResolution(designWidth, designHeight, SceneResolutionPolicy.ExactFit);

            scene = new Scenes.Level();
        }
    }
}

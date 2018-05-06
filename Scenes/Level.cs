using Nez;

namespace FlappyFlop.Scenes
{
    class Level : Scene
    {
        public override void initialize()
        {
            base.initialize();

            addRenderer(new DefaultRenderer());

            // Background
            addEntity(new Entities.Background());
            addEntity(new Entities.Background(firstPlayer: false));
            addEntity(new Entities.Background(isGround: true));
            addEntity(new Entities.Background(firstPlayer: false, isGround: true));

            // Player
            addEntity(new Entities.Player());
        }
    }
}
using StarHero.game.scenes.player;
using StarHero.game.support.manager;

namespace StarHero.game.scenes
{
    class TestWorldCreater : WorldCreater
    {
        public World CreateWorld()
        {
            World world = new World();
            world.AddGameObject(new TestPlayer(world));
            return world;
        }
    }
}

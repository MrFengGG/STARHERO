using StarHero.game.support;
using StarHero.game.support.manager;
using StarHero.resources;

namespace StarHero.game.scenes.player
{
    class TestPlayer : BaseGameObject
    {
        public float Speed { get; set; }
        public TestPlayer(World world) : base(world)
        {
            this.world = world;
            Speed = 10;
            Depth = 0.1f;
            CurrentSpirite = new support.spirite.Spirite(ResourceLoader.GetTexture("character"));
        }
    }
}

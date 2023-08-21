using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Gameplay.Player.Object;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Locations>().AsSingle();
            BindPlayer();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerObjectFactory>().AsSingle();
            Container.Bind<PlayerInputFactory>().AsSingle();
        }
    }
}
using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Gameplay.Player.Input;
using GameCore.CodeBase.Gameplay.Player.Object;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine.Implementations;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindPlayer();
            BindBullet();
            
            Container.Bind<Locations>().AsSingle();
            Container.Bind<LevelFactory>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerObjectFactory>().AsSingle();
            Container.Bind<PlayerInputFactory>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }

        private void BindBullet()
        {
            Container.Bind<BulletFactory>().AsSingle();
            Container.Bind<BulletPool>().AsSingle();
        }
    }
}
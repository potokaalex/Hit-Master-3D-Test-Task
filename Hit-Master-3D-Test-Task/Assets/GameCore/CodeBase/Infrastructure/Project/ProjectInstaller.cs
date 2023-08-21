using GameCore.CodeBase.Infrastructure.Project.Services.Data;
using GameCore.CodeBase.Infrastructure.Project.Services.SceneLoader;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine.Implementations;
using UnityEngine;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoaderScreen _sceneLoaderScreenPrefab;

        public override void InstallBindings()
        {
            BindStateMachine();
            BindSceneLoader();

            Container.Bind<IDataProvider>().To<DataProvider>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ISceneLoaderScreen>().To<SceneLoaderScreen>()
                .FromComponentInNewPrefab(_sceneLoaderScreenPrefab).AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        }
    }
}
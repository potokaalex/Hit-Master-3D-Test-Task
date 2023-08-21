using GameCore.CodeBase.Infrastructure.Project.Services.SceneLoader;
using GameCore.CodeBase.Infrastructure.Project.Services.StateMachine;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelLoadingState : IState
    {
        private const string LevelSceneName = "Level";
        private readonly ISceneLoader _sceneLoader;
        private readonly ISceneLoaderScreen _screen;

        public LevelLoadingState(ISceneLoader sceneLoader, ISceneLoaderScreen screen)
        {
            _sceneLoader = sceneLoader;
            _screen = screen;
        }

        public void Enter()
        {
            _screen.Show();
            _sceneLoader.LoadSceneAsync(LevelSceneName, () => _screen.Hide());
        }
    }
}
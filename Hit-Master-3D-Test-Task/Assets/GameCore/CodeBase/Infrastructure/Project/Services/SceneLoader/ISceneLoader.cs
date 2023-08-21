using System;

namespace GameCore.CodeBase.Infrastructure.Project.Services.SceneLoader
{
    public interface ISceneLoader
    {
        public void LoadSceneAsync(string sceneName, Action afterLoading = null);
    }
}
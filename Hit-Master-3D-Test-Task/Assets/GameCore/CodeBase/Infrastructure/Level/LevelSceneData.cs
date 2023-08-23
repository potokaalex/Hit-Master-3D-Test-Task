using System;
using GameCore.CodeBase.Gameplay.Location;
using GameCore.CodeBase.Gameplay.Player.Object;
using GameCore.CodeBase.Gameplay.Player;
using GameCore.CodeBase.Infrastructure.Project.Services.Data;

namespace GameCore.CodeBase.Infrastructure.Level
{
    [Serializable]
    public class LevelSceneData : IDataToProvide
    {
        public LocationObject[] LocationsData;
        public PlayerObjectData PlayerPrefab;
        public BulletObject BulletPrefab;
    }
}
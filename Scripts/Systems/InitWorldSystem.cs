using Leopotam.Ecs;
using UnityEngine;

public class InitWorldSystem : IEcsInitSystem
{
    public EcsWorld _world;
    public PrefabsCreator _prefab;
    public void Init()
    {
        var World = _world.NewEntity();
        var _WorldComponent = World.Get<WorldComponent>();
        var WorldGO = GameObject.Instantiate(_prefab.World);
    }
}

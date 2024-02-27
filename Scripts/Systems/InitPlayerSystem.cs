using Leopotam.Ecs;
using UnityEngine;

public class InitPlayerSystem : IEcsInitSystem
{
    public EcsWorld _world = new EcsWorld();
    public PrefabsCreator _prefab;
    public void Init()
    {
        var Player = _world.NewEntity();
        ref var _PlayerComponent = ref Player.Get<PlayerComponent>();
        var PlayerGO = GameObject.Instantiate(_prefab.Player);
        _PlayerComponent.PlayerGameObject = PlayerGO;
        _PlayerComponent.speed = 10;
    }

}

using Leopotam.Ecs;
using UnityEngine;

public class InitCameraSystem : IEcsInitSystem
{
    public EcsWorld _world = new EcsWorld();
    public PrefabsCreator _prefab;
    public EcsFilter<PlayerComponent> _filter;
    public GameObject PlayerGameObject;
    public void Init()
    {
        var Camera = _world.NewEntity();
        ref var _CameraComponent = ref Camera.Get<CameraComponent>();
        foreach (var c in _filter) 
        {
            ref var PlayerEntity = ref _filter.Get1(c);
            PlayerGameObject = PlayerEntity.PlayerGameObject;
        }
        var CameraGO = Object.Instantiate(_prefab.Camera, PlayerGameObject.transform);
        _CameraComponent.CameraTransform = CameraGO.transform;
        _CameraComponent.CameraRotation = CameraGO.transform.rotation;
        _CameraComponent.CameraPosition = CameraGO.transform.position;
    }

}

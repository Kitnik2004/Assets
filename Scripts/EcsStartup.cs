using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    public EcsWorld World;
    public EcsSystems Systems;
    public EcsSystems FixedSystems;
    public PrefabsCreator prefabs;
    private void Start()
    {
        World = new EcsWorld();
        Systems = new EcsSystems(World);
        FixedSystems = new EcsSystems(World);

        Systems
            .Add(new InitPlayerSystem())
            .Add(new InitCameraSystem())
            .Add(new InitWorldSystem())
            .Inject(prefabs)
            .Init();

        FixedSystems
            .Add(new MovePlayerSystem())
            .Init();
    }

    private void FixedUpdate()
    {
        FixedSystems.Run();
    }

    // Update is called once per frame
    private void Update()
    {
        Systems.Run();
    }

    private void OnDestroy()
    {
        FixedSystems.Destroy();
        Systems.Destroy();
        World.Destroy();
    }
}

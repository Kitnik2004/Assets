using Leopotam.Ecs;
using System;
using System.IO;
using UnityEngine;
public class MovePlayerSystem : IEcsRunSystem
{
    public EcsWorld _world = new EcsWorld();
    public EcsFilter<PlayerComponent> _filter;
    public PlayerComponent PlayerGO;
    [Serializable]
    public class PlayerPos 
    {
        public float posX;
        public float posY;
        public float posZ;
        public float rotX;
        public float rotY;
        public float rotZ;
        public float w;
    }

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref var PlayerGO = ref _filter.Get1(i);
            //Forward
            var VectorMoving = PlayerGO.PlayerGameObject.transform.right * Input.GetAxisRaw("Horizontal") + PlayerGO.PlayerGameObject.transform.forward * Input.GetAxisRaw("Vertical");
            PlayerGO.PlayerGameObject.GetComponent<CharacterController>().Move(VectorMoving);
            //Povorot
            PlayerGO.PlayerGameObject.transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 5, 0, Space.Self);
            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerGO.PlayerGameObject.GetComponent<Rigidbody>().AddForce(0, 500, 0, ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                SaveToJson(PlayerGO);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadFromJson(PlayerGO);
            }
        }
    }
    [ContextMenu("Load")]
    void LoadFromJson(PlayerComponent PlayerGO)
    {
        PlayerPos player = JsonUtility.FromJson<PlayerPos>(File.ReadAllText(Application.streamingAssetsPath + "/JSON.json"));
        Vector3 vector3_1 = new Vector3(player.posX, player.posY, player.posZ);
        Quaternion vector3_2 = new Quaternion(player.rotX, player.rotY, player.rotZ, player.w);
        PlayerGO.PlayerGameObject.transform.position = vector3_1;
        PlayerGO.PlayerGameObject.transform.rotation = vector3_2;
        //
    }
    [ContextMenu("Save")]
    void SaveToJson(PlayerComponent PlayerGO)
    {
        PlayerPos playerPos = new PlayerPos();
        playerPos.posX = PlayerGO.PlayerGameObject.transform.position.x;
        playerPos.posY = PlayerGO.PlayerGameObject.transform.position.y;
        playerPos.posZ = PlayerGO.PlayerGameObject.transform.position.z;
        playerPos.rotX = PlayerGO.PlayerGameObject.transform.rotation.x;
        playerPos.rotY = PlayerGO.PlayerGameObject.transform.rotation.y;
        playerPos.rotZ = PlayerGO.PlayerGameObject.transform.rotation.z;
        playerPos.w = PlayerGO.PlayerGameObject.transform.rotation.w;
        File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(playerPos));
    }

}

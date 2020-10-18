using System.Collections;
using System.Collections.Generic;
using ECS;
using Leopotam.Ecs;
using UnityEngine;

public class Loader : MonoBehaviour
{
    EcsWorld world;
    EcsSystems systems;
    EcsSystems systemsPhys;
    public Data mainData;

    void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);
        systemsPhys = new EcsSystems(world);
        systems.Add(new GameInitSystem());
        systems.Add(new PlayerInputSystem());
        systems.Add(new AnimatorSystem());
        systems.Add(new PlayerAttackSystem());
        systemsPhys.Add(new MoveSystem());
        systemsPhys.Add(new FollowSystem());
        
        systems.ProcessInjects();
        systemsPhys.ProcessInjects();
        systems.Init();
        systemsPhys.Init();
    }


    private void Update() {
        systems.Run();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        systemsPhys.Run();
        
    }

  

    private void OnDestroy() 
    {
        systems.Destroy();
        world.Destroy();
    }
    
   
}

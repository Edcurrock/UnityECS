using System.Collections;
using System.Collections.Generic;
using ECS;
using Leopotam.Ecs;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    EcsFilter<InputEventComponent> inputEventsFilter= null;

    public void Run()
    {
        var x = Input.GetAxis("Horizontal");
        var z= Input.GetAxis("Vertical");
        if(x != 0 || z!=0)
        {
            foreach(var i in inputEventsFilter)
            {
                var inputEvent = inputEventsFilter.Get1[i];
                inputEvent.direction = new Vector3(x,0,z);
            }
        }
        foreach (var i in inputEventsFilter)
        {
            var inputEvent = inputEventsFilter.Get1[i];
            inputEvent.isAttacked = Input.GetKeyDown("q");
        }

        foreach (var i in inputEventsFilter)
        {
            var inputEvent = inputEventsFilter.Get1[i];
            inputEvent.isJumped = Input.GetKeyDown("space");
        }
    }
}

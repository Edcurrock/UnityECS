using System.Collections;
using System.Collections.Generic;
using ECS;
using Leopotam.Ecs;
using UnityEngine;

public class MoveSystem : IEcsRunSystem
{
    EcsFilter<MovableComponent, InputEventComponent> playerMoveFilter= null;

    public void Run()
    {
      foreach (var item in playerMoveFilter)
      {
        var movableComponent = playerMoveFilter.Get1[item];
        var inputComponent = playerMoveFilter.Get2[item];

        if(movableComponent.transformCharacter != null)
          {
            movableComponent.transformCharacter.position += (Vector3)inputComponent.direction * 
                Time.deltaTime*movableComponent.speed;
            if(inputComponent.direction.normalized != Vector3.zero)
                movableComponent.transformCharacter.rotation = Quaternion.LookRotation(inputComponent.direction.normalized);
            if(inputComponent.isJumped)
            {
              movableComponent.transformCharacter.GetComponent<Rigidbody>().AddForce(Vector3.up*300f,ForceMode.Impulse);
            }
          }
        // Debug.Log(inputComponent.direction.sqrMagnitude);
        movableComponent.isMoving = inputComponent.direction.sqrMagnitude > 0.1f;
      }
    }
}

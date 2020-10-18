using System.Collections;
using System.Collections.Generic;
using ECS;
using Leopotam.Ecs;
using UnityEngine;

public class AnimatorSystem : IEcsRunSystem
{
    EcsFilter<MovableComponent, AnimatedCharacterComponent> animFilter= null;

    public void Run()
    {
      foreach (var item in animFilter)
      {
        var movableComponent = animFilter.Get1[item];
        var animComponent = animFilter.Get2[item];

        animComponent.animatorController.SetBool("IsMoving", movableComponent.isMoving);
      }
    }
}

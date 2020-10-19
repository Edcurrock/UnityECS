using System.Collections;
using System.Collections.Generic;
using ECS;
using Leopotam.Ecs;
using UnityEngine;

public class FollowSystem : IEcsRunSystem
{
    EcsFilter<FollowComponent, MovableComponent> enemyFollowFilter = null;

    public void Run()
    {
        foreach (var item in enemyFollowFilter)
        {
            var followComponent = enemyFollowFilter.Get1[item];
            var movableComponent = enemyFollowFilter.Get2[item];
            var direction = followComponent.target.position - movableComponent.transformCharacter.position;

            if (DistanceToTarget(followComponent,movableComponent) >= 1.5f)
            {
                followComponent.navMeshAgent.SetDestination(followComponent.target.position);    
            }
            movableComponent.isMoving = DistanceToTarget(followComponent, movableComponent) >= 1.5f;
            movableComponent.transformCharacter.LookAt(followComponent.target);
        }
    }

    private static float DistanceToTarget(FollowComponent followComponent, MovableComponent movableComponent)
    {
        return Vector3.Distance(followComponent.target.position,
                        movableComponent.transformCharacter.position);
    }
}

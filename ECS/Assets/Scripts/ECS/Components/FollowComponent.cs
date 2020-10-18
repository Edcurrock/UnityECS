using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS
{
    public class FollowComponent
    {
        [EcsIgnoreNullCheck]
        public Transform target;


        public void PrintAttack() => Debug.Log($"Attacked by {target.name}");
    }
}
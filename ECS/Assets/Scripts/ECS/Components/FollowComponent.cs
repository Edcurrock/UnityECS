using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace ECS
{
    public class FollowComponent
    {
        [EcsIgnoreNullCheck]
        public Transform target;
        [EcsIgnoreNullCheck]
        public NavMeshAgent navMeshAgent;

        public void PrintAttack(string s) => Debug.Log($"Attacked by {target.name}");
    }
}
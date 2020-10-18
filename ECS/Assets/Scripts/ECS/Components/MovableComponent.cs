using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS
{
    public class MovableComponent
    {
        [EcsIgnoreNullCheck]
        public Transform transformCharacter;
        public float speed;
        public bool isMoving;
    }
}
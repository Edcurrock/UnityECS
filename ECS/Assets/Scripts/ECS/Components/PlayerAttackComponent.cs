using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS
{
    public class PlayerAttackComponent
    {
        public float damage;
        public float damageDistance;
        public float timeToAttack;
        public float timer;
        public string tag;

        public delegate void AttackAction(string tag);
        public event AttackAction attackAct;

        public void OnAttack()
        {
            attackAct.Invoke(tag);
        }
    }
}
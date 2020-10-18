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
        
        public delegate void AttackAction();
        public event AttackAction attackAct;

        public void OnAttack()
        {
            attackAct.Invoke();
        }
    }
}
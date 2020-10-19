using System.Collections;
using System.Collections.Generic;
using ECS;
using Leopotam.Ecs;
using UnityEngine;

public class PlayerAttackSystem : IEcsRunSystem
{
    EcsFilter<InputEventComponent, PlayerAttackComponent, AnimatedCharacterComponent> attackFilter = null;

    public void Run()
    {
        foreach (var item in attackFilter)
        {
            var playerInput = attackFilter.Get1[item];
            var playerAttack = attackFilter.Get2[item];
            var playerAnimator = attackFilter.Get3[item];

            
           
            if(playerAttack.timer <= playerAttack.timeToAttack)
            {
                playerAttack.timer += Time.deltaTime;
            }
            if(playerInput.isAttacked && playerAttack.timer >= playerAttack.timeToAttack)
            {
                playerAnimator.animatorController.SetBool("Attack", playerInput.isAttacked);
                playerAttack.timer = 0;
                playerAttack.OnAttack();
            }
        }
    }

}

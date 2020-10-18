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

            
            playerAnimator.animatorController.SetBool("Attack", playerInput.isAttacked);
            if(playerInput.isAttacked)
            {
                playerAttack.OnAttack();
            }
        }
    }

}

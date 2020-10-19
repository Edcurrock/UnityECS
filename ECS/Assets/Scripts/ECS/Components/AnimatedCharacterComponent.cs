using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public class AnimatedCharacterComponent
{
    [EcsIgnoreNullCheck]
    public Animator animatorController;

    public void GetHit(string tag)
    {
        if(tag != animatorController.gameObject.tag)
        {
            animatorController.SetTrigger("GetHit");
        }
    }
}

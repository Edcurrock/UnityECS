using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

namespace ECS
{
    public class GameInitSystem : IEcsInitSystem
    {
        EcsWorld _world = null;

        public void Init()
        {

            Loader loader = GameObject.FindGameObjectWithTag("Loader").GetComponent<Loader>(); ;
            var player = _world.NewEntity();
            var playerMovableComponent = player.Set<MovableComponent>();
            player.Set<InputEventComponent>();
            var playerAnimator = player.Set<AnimatedCharacterComponent>();
            var playerAttack = player.Set<PlayerAttackComponent>();
            playerAttack.timeToAttack = loader.mainData.playerInitData.timeToAttack;
            playerAttack.timer = playerAttack.timeToAttack;
            playerAttack.tag = "Player";
            GameObject spawnedPlayerPrefab = GameObject.Instantiate(loader.mainData.playerInitData.playerPrefab,
                Vector3.zero, Quaternion.identity);

            playerAnimator.animatorController = spawnedPlayerPrefab.GetComponent<Animator>();
            playerMovableComponent.speed = loader.mainData.playerInitData.defaultSpeed;
            playerMovableComponent.transformCharacter = spawnedPlayerPrefab.transform;

            ///////////////////////////ENEMY//////////////////////////////////////////
            for(int i = 0; i < 3; i++)
                EnemySpawner(loader, playerMovableComponent, playerAttack, new Vector3(Random.Range(0,5),0,Random.Range(0, 5)));

        }

        private void EnemySpawner(Loader loader, MovableComponent playerMovableComponent, PlayerAttackComponent playerAttack, Vector3 spawnPos)
        {
            var enemy = _world.NewEntity();
            var enemyMovableComponent = enemy.Set<MovableComponent>();
            var enemyAnimator = enemy.Set<AnimatedCharacterComponent>();
            GameObject spawnedEnemyPrefab = GameObject.Instantiate(loader.mainData.enemyInitData.playerPrefab,
                spawnPos, Quaternion.identity);
            enemyAnimator.animatorController = spawnedEnemyPrefab.GetComponent<Animator>();

            enemyMovableComponent.speed = loader.mainData.enemyInitData.defaultSpeed;
            enemyMovableComponent.transformCharacter = spawnedEnemyPrefab.transform;

            var followComponent = enemy.Set<FollowComponent>();
            followComponent.target = playerMovableComponent.transformCharacter;
            followComponent.navMeshAgent = spawnedEnemyPrefab.GetComponent<NavMeshAgent>();
            followComponent.navMeshAgent.speed = enemyMovableComponent.speed;

            playerAttack.attackAct += followComponent.PrintAttack;
            playerAttack.attackAct += enemyAnimator.GetHit;
        }
    }
}

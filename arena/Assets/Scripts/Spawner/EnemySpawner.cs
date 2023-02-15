﻿using Components;
using Components.Movement;
using Infrastructure;
using Infrastructure.DI.Services.Factory;
using UnityEngine;

namespace Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyType _type;
        private IGameFactory _gameFactory;
        private Transform _playerTransform;

        public void Construct(IGameFactory gameFactory, Transform playerTransform, EnemyType type)
        {
            _gameFactory = gameFactory;
            _playerTransform = playerTransform;
            _type = type;
        }

        public void SpawnEnemy()
        {
            GameObject enemy = _gameFactory.CreateEnemy(transform.position, GetEnemyAssetPath());
            enemy.GetComponent<EnemyMovement>().Construct(_playerTransform);
            enemy.GetComponent<XpSpawner>().Construct(_gameFactory);
        }
        
        private string GetEnemyAssetPath()
        {
            return _type switch
            {
                EnemyType.SkeletonArcher => AssetsPath.SkeletonArcherPrefabPath,
                EnemyType.SkeletonSpearman => AssetsPath.SkeletonSpearmanPrefabPath,
                EnemyType.SkeletonWarrior => AssetsPath.SkeletonWarriorPrefabPath,
                _ => AssetsPath.SkeletonArcherPrefabPath
            };
        }
    }
}
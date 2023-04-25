using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData/EnemiesData", fileName = "EnemiesData")]
public class EnemiesData : ScriptableObject
{
    [SerializeField] private List<EnemyData> _enemies;

    [SerializeField] private List<EnemyData> Enemies => _enemies;
}

[System.Serializable]
public struct EnemyData
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
    [Space]
    [SerializeField] private float _maxShootAngle;
    [SerializeField] private float _health;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _timeToRepath;
    [SerializeField] private float _distanceToRepath;

    [HideInInspector] private Transform _transform;
}
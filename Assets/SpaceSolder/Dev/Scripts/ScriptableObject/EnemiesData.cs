using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData/EnemiesData", fileName = "EnemiesData")]
public class EnemiesData : ScriptableObject
{
    [SerializeField]  List<EnemyData> _enemies;

    [SerializeField] private List<EnemyData> enemies => _enemies;
   
}

[System.Serializable]
public struct EnemyData
{
    //public EnemiesData EnemiesData => _enemyData;

    //public EnemyData _enemyData;

    private Vector3 _position;
    private Quaternion _rotation;
    
    private float _maxShootAngle;
    private float _health;
    private float _currentHealth;
    private float _attackRange;
    private float _timeToRepath;
    private float _distanceToRepath;

    public float MaxAimAngle => _maxAimAngle;
    public float MaxAimDistance => _maxAimDistance;

    [HideInInspector] private Transform _transform;
    private float _maxAimAngle;
    private float _maxAimDistance;

    public void Init(EnemyData enemyData, Transform transform, Vector3 vector3, Quaternion quaternion)
    {
        _transform = transform;
        _position = vector3;
        _rotation = quaternion;        

    }
}
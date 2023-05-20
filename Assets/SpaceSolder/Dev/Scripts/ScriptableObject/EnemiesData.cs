using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData/EnemiesData", fileName = "EnemiesData")]
public class EnemiesData : ScriptableObject
{
    [SerializeField] private EnemyData _defaultEnemyData;
    [Space]
    [SerializeField] private List<EnemyData> _enemies;

    public List<EnemyData> GetEnemies()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            var enemy = _enemies[i];

            if (enemy.Prafab == null)
                enemy.Prafab = _defaultEnemyData.Prafab;

            if (enemy.Position == Vector3.zero)
                enemy.Position = _defaultEnemyData.Position;

            if (enemy.Rotation == Quaternion.identity)
                enemy.Rotation = _defaultEnemyData.Rotation;

            if (enemy.MaxShootAngle == 0f)
                enemy.MaxShootAngle = _defaultEnemyData.MaxShootAngle;

            if (enemy.Health == 0f)
                enemy.Health = _defaultEnemyData.Health;    

            if (enemy.CurrentHealth == 0f)
                enemy.CurrentHealth = _defaultEnemyData.CurrentHealth;

            if (enemy.AttackRange == 0f)
                enemy.AttackRange = _defaultEnemyData.AttackRange;

            if (enemy.TimeToRepath == 0f)
                enemy.TimeToRepath = _defaultEnemyData.TimeToRepath;

            if (enemy.DistanceToRepath == 0f)
                enemy.DistanceToRepath = _defaultEnemyData.DistanceToRepath;

            if (enemy.MaxAimAngle == 0f)
                enemy.MaxAimAngle = _defaultEnemyData.MaxAimAngle;

            if (enemy.MaxAimDistance == 0f)
                enemy.MaxAimDistance = _defaultEnemyData.MaxAimDistance;
        }

        return _enemies;

    }

}

[System.Serializable]
public class EnemyData
{
    public EnemySoldierController Prafab;
    public Vector3 Position;
    public Quaternion Rotation;    
    public float MaxShootAngle;
    public float Health;
    public float CurrentHealth;
    public float AttackRange;    
    public float TimeToRepath;
    public float DistanceToRepath;     
    public float MaxAimAngle;
    public float MaxAimDistance;
}


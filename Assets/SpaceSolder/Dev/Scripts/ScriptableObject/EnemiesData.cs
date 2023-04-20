using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelData/EnemiesData", fileName = "EnemiesData")]
public class EnemiesData : ScriptableObject
{
    [SerializeField] private List<EnemyData> enemies;

    public List<EnemyData> Enemies => enemies;
}

[System.Serializable]
public struct EnemyData
{
    public Vector3 Position;
    public Quaternion Rotation;
    [Space]
    public float MaxShootAngle;
    public float Health;
    public float CurrentHealth;
    public float AttackRange;
    public float TimeToRepath;
    public float DistanceToRepath;

    [HideInInspector] public Transform Transform;
}
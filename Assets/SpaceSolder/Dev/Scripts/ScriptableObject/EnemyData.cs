using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Scriptable Object")]

public class EnemyData : ScriptableObject
{
    public Transform[] enemies;

    
    //[SerializeField] private Transform _playerTransform;
    //[SerializeField] private float _maxShootAngle;
    //[SerializeField] private float _health;
    //[SerializeField] private float _currentHealth;
    //[SerializeField] private float _attackRange;
    //[SerializeField] private float _timeToRepath;
    //[SerializeField] private float _distanceToRepath;

}

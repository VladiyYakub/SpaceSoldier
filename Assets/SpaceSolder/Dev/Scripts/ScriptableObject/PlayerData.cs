using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;    
    public GameObject PlayerPrefab;    
    [Space]
    [SerializeField] private float _playerGrounDistance;
    [SerializeField] private float _playerAntistuckOffset;
    [SerializeField] private float _fallFakeDistance;
    [SerializeField] private float _fallSpeed;
    [Space]
    [SerializeField] private float _startMove;
    [SerializeField] private float _moveSpeed;
    [Space]    
    [SerializeField] private float _maxVerticalAngle;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [Space]    
    [SerializeField] private float _maxAimAngle;
    [SerializeField] private float _maxAimDistance;    
    [Space]    
    [SerializeField] private float _shotDistance;
    [SerializeField] private float _delay;   
    [Space]    
    [SerializeField] private int _maxBullets;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private  int _maxHealth;
    [SerializeField] private  int _currentHealth;
}

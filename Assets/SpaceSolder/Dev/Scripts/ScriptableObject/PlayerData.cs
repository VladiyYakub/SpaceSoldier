using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Spawn Data")]
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private Quaternion _playerRotation;
    [SerializeField] private Player _playerPrefab;
    [Space]

    [Header("Input Data")]
    [SerializeField] private float _startMove;
    [SerializeField] private float _moveSpeed;
    [Space]
    [SerializeField] private float _maxVerticalAngle;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [Space]

    [Header("Temp")]
    [SerializeField] private float _playerGrounDistance;
    [SerializeField] private float _playerAntistuckOffset;
    [SerializeField] private float _fallFakeDistance;
    [SerializeField] private float _fallSpeed;
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


    public Vector3 PlayerPosition => _playerPosition;
    public Quaternion PlayerRotation => _playerRotation;
    public Player PlayerPrefab => _playerPrefab;


    public float StartMove => _startMove;
    public float MoveSpeed => _moveSpeed;
    public float MaxVerticalAngle => _maxVerticalAngle;
    public float HorizontalSpeed => _horizontalSpeed;
    public float VerticalSpeed => _verticalSpeed;
}

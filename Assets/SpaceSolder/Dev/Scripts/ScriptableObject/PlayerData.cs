using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Spawn Data")]
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private Quaternion _playerRotation;
    [SerializeField] private Player _playerPrefab;
    
    [Header("Movement")]
    [SerializeField] private float _startMove;
    [SerializeField] private float _moveSpeed;
    
    [Header("Rotation")]
    [SerializeField] private float _maxVerticalAngle;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;

    [Header("Temp")]
    [SerializeField] private float _playerGrounDistance;
    [SerializeField] private float _playerAntistuckOffset;
    [SerializeField] private float _fallFakeDistance;
    [SerializeField] private float _fallSpeed;

    [Header("Enemy")]
    [SerializeField] private float _maxAimAngle;
    [SerializeField] private float _maxAimDistance;   
    
    [Header("Shoot")]
    [SerializeField] private float _shotDistance;
    [SerializeField] private float _delay;      

    [Header("BulletController")]
    [SerializeField] private int _maxBullets;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    [Header(("HealthController"))]
    [SerializeField] private  int _maxHealth;
    [SerializeField] private  int _currentHealth;
   

    public Vector3 PlayerPosition => _playerPosition;
    public Quaternion PlayerRotation => _playerRotation;
    public Player PlayerPrefab => _playerPrefab;


    public Button ShootButton => _shootButton;
    public EnemiesData EnemiesData => _enemyData;


    public Button _shootButton;
    public EnemiesData _enemyData;


    public float StartMove => _startMove;
    public float MoveSpeed => _moveSpeed;
    public float MaxVerticalAngle => _maxVerticalAngle;
    public float HorizontalSpeed => _horizontalSpeed;
    public float VerticalSpeed => _verticalSpeed;


    public float MaxAimAngle => _maxAimAngle;
    public float MaxAimDistance => _maxAimDistance;

}

using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rbPlayer;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _animator;
    [Space]
    [SerializeField] private Transform _origin;
    [SerializeField] private float _playerGrounDistance;
    [SerializeField] private float _playerAntistuckOffset;
    [SerializeField] private float _fallFakeDistance;
    [SerializeField] private float _fallSpeed;
    [Space]
    [SerializeField] private FixedJoystick _moveJoyastick;
    [SerializeField] private float _startMove;
    [SerializeField] private float _moveSpeed;
    [Space]
    [SerializeField] private FixedJoystick _loockJoystick;
    [SerializeField] private float _maxVerticalAngle;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [Space]
    [SerializeField] private Button _shootButton;
    [SerializeField] private float _maxAimAngle;
    [SerializeField] private float _maxAimDistance;
    [SerializeField] private EnemiesData _enemyData;
    [Space]
    [SerializeField] private Weapon _weapon;
    [Space]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _shotEffect;
    [SerializeField] private float _shotDistance;
    [SerializeField] private float _delay;
    [SerializeField] private Collider[] dontCollideWith;
    [Space]
    [SerializeField] private GameObject _shootPointDecal;
    [SerializeField] private int _maxBullets;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [Space]
    [SerializeField] private Image _barBackground;
    [SerializeField] private Image _fullHealth;
    [SerializeField] private Image _midddleHealth;
    [SerializeField] private Image _lowHealth;
    [Space]
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
}

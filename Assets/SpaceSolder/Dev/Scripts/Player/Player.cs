using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [Space]
    [Header("Components")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;
   
    private PlayerData _playerData;

    public void Init(PlayerData playerData, FixedJoystick moveJoystick)
    {
        _playerData = playerData;

        _playerMovement.Init(playerData, _rigidbody, _animator, moveJoystick);
        
    }

    [Space]
    [SerializeField] private Transform _origin;
    [Space]
    [SerializeField] private FixedJoystick _moveJoyastick;
    [Space]
    [SerializeField] private FixedJoystick _loockJoystick;
    [Space]    
    [SerializeField] private EnemiesData _enemyData;
    [Space]
    [SerializeField] private Weapon _weapon;
    [Space]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Collider[] dontCollideWith;
    [Space]
    [SerializeField] private GameObject _shootPointDecal;
    [Space]
    [SerializeField] private Image _barBackground;
    [SerializeField] private Image _fullHealth;
    [SerializeField] private Image _midddleHealth;
    [SerializeField] private Image _lowHealth;
}

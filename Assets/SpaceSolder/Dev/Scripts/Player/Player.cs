using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _animator;
    [Space]
    [SerializeField] private Transform _origin;
    [Space]
    [SerializeField] private FixedJoystick _moveJoyastick;
    [Space]
    [SerializeField] private FixedJoystick _loockJoystick;
    [Space]
    [SerializeField] private Button _shootButton;
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
    

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private EnemiesData _enemiesData;
    [Space]
    [SerializeField] FixedJoystick _movementJoystick;
    [SerializeField] FixedJoystick _lookJoystick;
    [SerializeField] Button _shootButton;

    private Player _player;

    private void Awake()
    {
        _player = Instantiate(_playerData.PlayerPrefab, _playerData.PlayerPosition, _playerData.PlayerRotation);
        _player.Init(_playerData, _movementJoystick);
    }  

}

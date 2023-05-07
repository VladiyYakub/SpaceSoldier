using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    [SerializeField] private PlayerData _playerData;
    [Space]
    [SerializeField] FixedJoystick _movementJoystick;
    [SerializeField] FixedJoystick _lookJoystick;

    private Player _player;

    private void Awake()
    {
        _player = Instantiate(_playerData.PlayerPrefab, _playerData.PlayerPosition, _playerData.PlayerRotation);
        _player.Init(_playerData, _movementJoystick);
    }
}

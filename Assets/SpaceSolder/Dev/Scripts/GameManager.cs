using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Transform _spawnPoint;
    private void Start()
    {        
        Vector3 playerPosition = _playerData.PlayerPosition;
        Quaternion playerRotation = _playerData.PlayerRotation;
        
        GameObject playerObject = Instantiate(_playerPrefab, playerPosition, playerRotation);

        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        playerController.Init(_playerData);
    }
}

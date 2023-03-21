using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private Transform _origin;
    [SerializeField] private float _playerGrounDistance;
    [SerializeField] private float _playerAntistuckOffset;
    [SerializeField] private float _fallFakeDistance;
    [SerializeField] private float _fallSpeed;

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(_origin.position, Vector3.down, out hit))
        {
            float distance = Vector3.Distance(_origin.position, hit.point);

            if (distance > _playerGrounDistance)
            {
                Debug.Log("Down");
                CorrectPlayerHeight(distance - _playerGrounDistance);
            }
            else if (distance < _playerGrounDistance + _playerAntistuckOffset)
            {
                Debug.Log("Up");
                CorrectPlayerHeight(-(_playerGrounDistance - distance));
            }
        }
        else
        {
            CorrectPlayerHeight(_fallFakeDistance);
        }
    }

    private void CorrectPlayerHeight(float distance)
    {
        Vector3 playerPos = transform.position;
        playerPos = Vector3.Lerp(playerPos, playerPos + Vector3.down * distance, _fallSpeed);
        transform.position = playerPos;
    }
}


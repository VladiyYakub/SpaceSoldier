using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private float _playerGrounDistance;
    [SerializeField] private float _fallFakeDistance;
    [SerializeField] private float _fallSpeed;
    
    //private void FixedUpdate()
    //{
    //    RaycastHit _hit;
    //    if (Physics.Raycast(transform.position, Vector3.down, out _hit))
    //    {
    //        if (_hit.distance < _playerGrounDistance)
    //        {
    //            CorrectPlayerHeight(_hit.distance);
    //        }
    //    }
    //    else
    //    {
    //        CorrectPlayerHeight(_fallFakeDistance);
    //    }
    //}

    //private void CorrectPlayerHeight(float distance)
    //{
    //    Vector3 playerPos = transform.position;
    //    playerPos.y = Mathf.Lerp(playerPos.y, _hit.point.y + _playerGrounDistance, _fallSpeed);
    //    transform.position = playerPos;
    //}

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float distance = Vector3.Distance(transform.position, hit.point);
            if (distance < _playerGrounDistance)
            {
                CorrectPlayerHeight(hit.point);
            }
        }
        else
        {
            CorrectPlayerHeight(transform.position + Vector3.down * _fallFakeDistance);
        }
    }

    //private void CorrectPlayerHeight(Vector3 targetPosition)
    //{
    //    Vector3 playerPos = transform.position;
    //    playerPos.y = Mathf.Lerp(playerPos.y, targetPosition.y + _playerGrounDistance, _fallFakeDistance);
    //    transform.position = playerPos;
    //}
    private void CorrectPlayerHeight(Vector3 targetPosition)
    {
        Vector3 playerPos = transform.position;
        //playerPos.y = Mathf.Lerp(playerPos.y, targetPosition.y + _playerGrounDistance, _fallSpeed * Time.deltaTime);
        //transform.position = playerPos;
        playerPos = Vector3.Lerp(playerPos, targetPosition + Vector3.up * _playerGrounDistance, _fallSpeed * Time.deltaTime);
        transform.position = playerPos;

    }

}


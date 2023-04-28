using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _startToMoveOn;
    [SerializeField] private FixedJoystick _moveJoystick;
    [SerializeField] private float _moveSpeed;

    private Vector3 _moveDirection;

    private void FixedUpdate()
    {
        CalculateMoveDirection();
        UpdatePosition();
    }

    private void CalculateMoveDirection()
    {
        _moveDirection = new Vector3(_moveJoystick.Horizontal, 0, _moveJoystick.Vertical) * _moveSpeed;
    }

    private void UpdatePosition()
    {
        var isAbleToMove = _moveJoystick.Horizontal > _startToMoveOn || _moveJoystick.Vertical > _startToMoveOn ||
            _moveJoystick.Horizontal < -_startToMoveOn || _moveJoystick.Vertical < -_startToMoveOn;

        if (isAbleToMove)
        {
            _rb.velocity = Quaternion.LookRotation(transform.forward) * _moveDirection;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _rb.velocity = Vector3.zero;
            _animator.SetBool("isRunning", false);
        }
    }
}


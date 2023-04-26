using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _moveJoystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _startToMoveOn;
    [SerializeField] private Animator _animator;

    private Vector3 _moveDirection;

    private void FixedUpdate()
    {
        CalculateMoveDirection();
        UpdatePosition();
    }

    private void CalculateMoveDirection()
    {
        _moveDirection = new Vector3(_moveJoystick.Horizontal * _moveSpeed, 0, _moveJoystick.Vertical * _moveSpeed);
    }

    private void UpdatePosition()
    {
        var isAbleToMove = _moveJoystick.Horizontal > _startToMoveOn || _moveJoystick.Vertical > _startToMoveOn ||
            _moveJoystick.Horizontal < -_startToMoveOn || _moveJoystick.Vertical < -_startToMoveOn;

        if (isAbleToMove)
        {
            _rb.velocity = transform.forward * _moveSpeed;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _rb.velocity = Vector3.zero;
            _animator.SetBool("isRunning", false);
        }
    }
}

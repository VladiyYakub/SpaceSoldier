using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;
    private FixedJoystick _moveJoystick;
    private Vector3 _moveDirection;

    private float _startToMoveOn;
    private float _moveSpeed;

    public void Init(PlayerData playerData, Rigidbody rigidbody, Animator animator, FixedJoystick joystick)
    {
        _rb = rigidbody;
        _animator = animator;
        _moveJoystick = joystick;

        _startToMoveOn = playerData.StartMove;
        _moveSpeed = playerData.MoveSpeed;
    }

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


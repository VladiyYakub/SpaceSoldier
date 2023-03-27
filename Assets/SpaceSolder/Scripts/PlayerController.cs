using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystickMove;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _movespeed;
    [SerializeField] private float _startToMoveOn;
    [SerializeField] private Button _shootButton;
    public GameObject bullet;
    public float speedBullet;

    private Vector3 _moveDirection;

    private void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        CalculateMoveDirection();
        UpdateRotation();
        UpdatePosition();
    }
    private void CalculateMoveDirection()
    {
        _moveDirection = new Vector3(_joystickMove.Horizontal * _movespeed, 0,
        _joystickMove.Vertical * _movespeed);
    }

    private void UpdateRotation()
    {
        if (_joystickMove.Horizontal != 0 || _joystickMove.Vertical != 0)
        {
            Quaternion lookDirection = transform.rotation * Quaternion.LookRotation(_moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, 0.05f);
        }
    }

    private void UpdatePosition()
    {
        var isAbleToMove = _joystickMove.Horizontal > _startToMoveOn || _joystickMove.Vertical > _startToMoveOn || 
            _joystickMove.Horizontal < -_startToMoveOn || _joystickMove.Vertical < -_startToMoveOn;

        if (isAbleToMove)
        {
            _rb.velocity = transform.forward * _movespeed;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _rb.velocity = Vector3.zero;
            _animator.SetBool("isRunning", false);
        }
    }
}


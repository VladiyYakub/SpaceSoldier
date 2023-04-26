using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [Space]
    [SerializeField] private FixedJoystick _moveJoystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lookSpeed;
    [SerializeField] private float _startToMoveOn;
    [Space]
    [SerializeField] private FixedJoystick _lookJoystick;
    [SerializeField] private float _cameraAngel;
    [SerializeField] private float _cameraAngelSpeed;
    [Space]
    [SerializeField] private UIVirtualTouchZone _touchZone;
    [Space]
    [SerializeField] private Animator _animator;
    [Space]
    [SerializeField] private Button _shootButton;

    private Vector3 _moveDirection;
    private void FixedUpdate()
    {
        CalculateMoveDirection();
        UpdateRotation();
        UpdatePosition();
    }
    private void CalculateMoveDirection()
    {
        _moveDirection = new Vector3(_moveJoystick.Horizontal * _moveSpeed, 0,
        _moveJoystick.Vertical * _moveSpeed);
    }

    private void UpdateRotation()
    {
        if (_moveJoystick.Horizontal != 0 || _moveJoystick.Vertical != 0)
        {
            Quaternion lookDirection = transform.rotation * Quaternion.LookRotation(_moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, 0.05f);
        }
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
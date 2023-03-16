using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystickMove;
    [SerializeField] private FixedJoystick _joystickLook;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _movespeed;

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_joystickMove.Horizontal * _movespeed, _rb.velocity.y, _joystickMove.Vertical * _movespeed);

        //        if (_joystickLook.Horizontal != 0 || _joystickLook.Vertical != 0)
        //        {
        //            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        //            _animator.SetBool("isRunning", true);
        //        }
        //        else
        //        {
        //            _animator.SetBool("isRunning", false);
        //        }
    }

    //[SerializeField] public FixedJoystick _moveJoystick;
    //[SerializeField] private Rigidbody _rb;
    //[SerializeField] private Animator _animation;
    ////[SerializeField] private float _speed;
    //private void Update()
    //{
    //    float horiz = _moveJoystick.Horizontal; 
    //    float vert = _moveJoystick.Vertical;
    //    Vector3 direction = new Vector3(horiz, 0, vert).normalized;
    //    transform.Translate(direction * 0.02f, Space.World);
    //}

}


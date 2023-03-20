using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystickMove;
    //[SerializeField] private FixedJoystick _joystickLook;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _movespeed;

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_joystickMove.Horizontal * _movespeed, _rb.velocity.y, _joystickMove.Vertical * _movespeed);

        if (_joystickMove.Horizontal != 0 || _joystickMove.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    

}


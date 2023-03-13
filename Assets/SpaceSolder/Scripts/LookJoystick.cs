using UnityEngine;

public class LookJoystick : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3();

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
            
        }       
    }
}


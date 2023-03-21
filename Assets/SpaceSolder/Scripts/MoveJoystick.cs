using UnityEngine;
public class MoveJoystick : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public Joystick _moveJoystick;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = _moveJoystick.Horizontal;
        float vertical = _moveJoystick.Vertical;

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        _rb.AddForce(movement * _speed);
    }

    //private void FixedUpdate()
    //{
    //    _rb.velocity = new Vector3(_moveJoystick.Horizontal * _speed, _rb.velocity.y, _moveJoystick.Vertical * _speed);
    //}
}

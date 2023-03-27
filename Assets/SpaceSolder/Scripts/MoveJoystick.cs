using UnityEngine;
public class MoveJoystick : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    public float speed;
    public Joystick moveJoystick;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = moveJoystick.Horizontal;
        float vertical = moveJoystick.Vertical;

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        _rb.AddForce(movement * speed);
    }

    //private void FixedUpdate()
    //{
    //    _rb.velocity = new Vector3(_moveJoystick.Horizontal * _speed, _rb.velocity.y, _moveJoystick.Vertical * _speed);
    //}
}

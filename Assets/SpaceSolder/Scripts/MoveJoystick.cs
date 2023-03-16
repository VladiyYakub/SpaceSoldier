using UnityEngine;
using UnityEngine.UI;

public class MoveJoystick : MonoBehaviour
{
   [SerializeField] public float _speed = 10f;
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
}

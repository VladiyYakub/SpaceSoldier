using UnityEngine;
public class LookJoystick : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _rotateSpeed;
    [SerializeField] public Joystick _joystick;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = _joystick.Horizontal;
        float moveVertical = _joystick.Vertical;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);        
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, _rotateSpeed * Time.deltaTime);
        }        
        rb.AddForce(movement * _speed);
    }
}

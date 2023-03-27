using UnityEngine;
public class LookJoystick : MonoBehaviour
{
     [SerializeField] private Rigidbody _rb;
     public float speed;
     public float rotateSpeed;
     public Joystick joystick;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);        
        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            _rb.rotation = Quaternion.Slerp(_rb.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }        
        _rb.AddForce(movement * speed);
    }
}

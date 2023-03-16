using UnityEngine;
using UnityEngine.UI;

public class LookJoystick : MonoBehaviour
{
   [SerializeField] public float _rotationSpeed = 100f;
   [SerializeField] public Joystick _joystick;

    void FixedUpdate()
    {
        float horizontal = _joystick.Horizontal;
        float vertical = _joystick.Vertical;

        transform.Rotate(0, horizontal * _rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(-vertical * _rotationSpeed * Time.deltaTime, 0, 0);
    }
}

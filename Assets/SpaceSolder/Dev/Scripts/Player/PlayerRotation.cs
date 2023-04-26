using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private FixedJoystick _lookJoystick;
    [SerializeField] private float _cameraAngle;
    [SerializeField] private float _cameraAngleSpeed;

    private void FixedUpdate()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        if (_lookJoystick.Horizontal != 0 || _lookJoystick.Vertical != 0)
        {
            float angle = Mathf.Atan2(_lookJoystick.Horizontal, _lookJoystick.Vertical) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, angle + _cameraAngle, 0));
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _cameraAngleSpeed * Time.deltaTime);
        }
    }
}

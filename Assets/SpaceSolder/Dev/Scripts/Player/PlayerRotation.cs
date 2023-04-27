using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private FixedJoystick _lookJoystick;
    [SerializeField] private float _cameraAngle;
    [SerializeField] private float _cameraAngleSpeed;

    private float _xRotation = 0f;

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float x = _lookJoystick.Vertical * _cameraAngleSpeed * Time.deltaTime;
        _xRotation -= x;
        _xRotation = Mathf.Clamp(_xRotation, -_cameraAngle, _cameraAngle);

        float y = _lookJoystick.Horizontal * _cameraAngleSpeed * Time.deltaTime;
        _playerTransform.Rotate(Vector3.up * y);

        transform.rotation = Quaternion.Euler(_xRotation, _playerTransform.rotation.eulerAngles.y, 0f);
    }
}

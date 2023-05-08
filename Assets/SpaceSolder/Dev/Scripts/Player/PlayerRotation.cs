using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Transform _playerTransform;
    private FixedJoystick _lookJoystick;

    private float _maxVerticalAngle;
    private float _horisontalSpeed;
    private float _verticalSpeed;

    private float _verticalOffset = 0f;

    public void Init(PlayerData playerData, Transform transform, FixedJoystick joystick)
    {
        _lookJoystick = joystick;
        _playerTransform = transform;

        _maxVerticalAngle = playerData.MaxVerticalAngle;
        _horisontalSpeed = playerData.HorizontalSpeed;
        _verticalSpeed = playerData.VerticalSpeed;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float x = _lookJoystick.Horizontal * _horisontalSpeed * Time.deltaTime;
        float y = _lookJoystick.Vertical * _verticalSpeed * Time.deltaTime;

        y = ApplyOffset(y) ? 0 : y;

        _playerTransform.Rotate(Vector3.up * x, Space.World);
        _playerTransform.Rotate(Vector3.left * y);
    }

    private bool ApplyOffset(float modifier)
    {
        _verticalOffset += modifier;

        if (_verticalOffset >= _maxVerticalAngle)
        {
            _verticalOffset = _maxVerticalAngle;
            return true;
        }
        
        if (_verticalOffset <= -_maxVerticalAngle)
        {
            _verticalOffset = -_maxVerticalAngle;
            return true;
        }

        return false;
    }
}

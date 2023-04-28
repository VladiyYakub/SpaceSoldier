using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private FixedJoystick _lookJoystick;
    [SerializeField] private float _maxVerticalAngle;
    [SerializeField] private float _horisontalSpeed;
    [SerializeField] private float _verticalSpeed;

    private float _verticalOffset = 0f;

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

    /// <summary>
    /// 
    /// </summary>
    /// <returns>true if offset was applied</returns>
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

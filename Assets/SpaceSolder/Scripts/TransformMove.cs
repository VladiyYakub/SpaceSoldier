using UnityEngine;

public class TransformMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSensitivity;

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float r = Input.GetAxisRaw("Mouse X");

        Vector3 offset = new Vector3 (h, 0, v) * Time.deltaTime * _speed;
        transform.Translate (offset);
        transform.Rotate(0f, r * _rotationSensitivity, 0f);
    }
}

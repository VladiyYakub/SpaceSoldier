using UnityEngine;

public class CameraBillBoard : MonoBehaviour
{
    [SerializeField] private bool _billboardX = true;
    [SerializeField] private bool _billboardY = true;
    [SerializeField] private bool _billboardZ = true;
    [SerializeField] private float _offsetToCamera;
    protected Vector3 localStartPosition;    
    void Start()
    {
        localStartPosition = transform.localPosition;
    }    
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                                                               Camera.main.transform.rotation * Vector3.up);
        if (!_billboardX || !_billboardY || !_billboardZ)
            transform.rotation = Quaternion.Euler(_billboardX ? transform.rotation.eulerAngles.x : 0f, _billboardY ? transform.rotation.eulerAngles.y : 0f, _billboardZ ? transform.rotation.eulerAngles.z : 0f);
        transform.localPosition = localStartPosition;
        transform.position = transform.position + transform.rotation * Vector3.forward * _offsetToCamera;
    }
}

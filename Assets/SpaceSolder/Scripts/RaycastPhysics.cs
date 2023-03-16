//using UnityEngine;

//public class RaycastPhysics : MonoBehaviour
//{
//    [SerializeField] public float _maxDistance;
//    [SerializeField] public float _force;
//    [SerializeField] public LayerMask layerMask;

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            RaycastHit hit;
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            if (Physics.Raycast(ray, out hit, _maxDistance, layerMask))
//            {
//                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

//                if (rb != null)
//                {
//                    rb.AddForceAtPosition(ray.direction * _force, hit.point, ForceMode.Impulse);
//                }
//            }
//        }
//    }
//}

using UnityEngine;

public class RaycastPhysics : MonoBehaviour
{
    [SerializeField] public Transform _playerTransform;

    void Start()
    {
        _playerTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(_playerTransform.position, _playerTransform.forward, out hit))
        {
            Debug.Log("Hit in  " + hit.collider.name);
        }
        else
        {
            Debug.Log("Don't hin in any object");
        }
    }
}

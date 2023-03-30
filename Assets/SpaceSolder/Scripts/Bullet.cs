using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Vector3 _target;
    private bool _isFlying = false;

    public void FlyToPoint(Vector3 target)
    {
        this._target = target;
        _isFlying = true;
    }

    private void Update()
    {
        if (_isFlying)
        {
            Vector3 direction = new Vector3(10f, 0, 0);
            transform.position += direction * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, _target) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}





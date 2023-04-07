using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public int damage;
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthController>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

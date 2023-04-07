using UnityEngine;

public class EnemySoldierController : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public int damage = 20;
    public float attackRange = 100f;
    public float fireRate = 1f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private Transform _player;
    private float _nextFireTime = 1f;
    private bool _isDead = false;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (!_isDead && _player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

            if (distanceToPlayer <= attackRange)
            {
                transform.LookAt(_player);

                if (Time.time >= _nextFireTime)
                {
                    _nextFireTime = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20f;
        Destroy(bullet, 2f);
    }

    public void TakeDamage(int damage)
    {
        if (!_isDead)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        _isDead = true;
        Destroy(gameObject, 2f);
    }
}

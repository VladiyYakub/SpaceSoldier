using UnityEngine;
using UnityEngine.AI;

public class EnemySoldierController : MonoBehaviour, IDamageReceiver
{
    public float health = 100;
    public float attackRange = 100f;

    public Transform playerTransform;
    public float timeTuRepath;
    public float distanceToRepath;

    NavMeshAgent soldierEnemy;
    Animator animator;
    float timer = 0.0f;

    private bool _isDead = false;

    private void Start()
    {
        soldierEnemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isDead) return;

        timer -= Time.deltaTime;
        animator.SetFloat("Speed", soldierEnemy.velocity.magnitude);

        if (timer > 0.0f) return;

        if (Vector3.Distance(playerTransform.position, transform.position) < attackRange)
        {
            float spDistance = Vector3.Distance(playerTransform.position, soldierEnemy.destination);

            if (spDistance > distanceToRepath)
                soldierEnemy.destination = playerTransform.position;
        }

        timer = timeTuRepath;
    }

    public void GetDamage(float damage)
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

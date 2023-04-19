using UnityEngine;
using UnityEngine.AI;

public class EnemySoldierController : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _attackRange;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _timeTuRepath;
    [SerializeField] private float _distanceToRepath;

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

        if (Vector3.Distance(_playerTransform.position, transform.position) < _attackRange)
        {
            float spDistance = Vector3.Distance(_playerTransform.position, soldierEnemy.destination);

            if (spDistance > _distanceToRepath)
                soldierEnemy.destination = _playerTransform.position;
        }

        timer = _timeTuRepath;
    }

    public void GetDamage(float damage)
    {
        if (!_isDead)
        {
            _health -= damage;
            if (_health <= 0)
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

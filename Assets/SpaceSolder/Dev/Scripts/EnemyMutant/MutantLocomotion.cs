using UnityEngine;
using UnityEngine.AI;
public class MutantLocomotion : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent mutantEnemy;
    Animator animator;

    private void Start()
    {
        mutantEnemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        mutantEnemy.destination = playerTransform.position;
        animator.SetFloat("Walk", mutantEnemy.velocity.magnitude);
    }
}

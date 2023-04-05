using UnityEngine;
using UnityEngine.AI;
public class MutantLocomotion : MonoBehaviour
{
    public Transform playerTransform;
    NavMeshAgent agent;
    Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        agent.destination = playerTransform.position;
        animator.SetFloat("Walk", agent.velocity.magnitude);
    }
}

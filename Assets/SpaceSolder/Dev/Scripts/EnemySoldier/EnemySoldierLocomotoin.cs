using UnityEngine;
using UnityEngine.AI;
public class EnemySoldierLocomotoin : MonoBehaviour
{
    public Transform playerTransform;
    public float maxTime;
    public float maxDIstance;

    NavMeshAgent soldierEnemy;
    Animator animator;
    float timer = 0.0f;

    private void Start()
    {
        soldierEnemy = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            float spDistance = (playerTransform.position - soldierEnemy.destination).sqrMagnitude;
            if(spDistance > maxDIstance * maxDIstance) 
            {
                soldierEnemy.destination = playerTransform.position;
            }
            timer = maxTime;
         }
        animator.SetFloat("Speed", soldierEnemy.velocity.magnitude);
    }
}

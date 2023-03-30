using UnityEngine;

public class DestroyByDelay : MonoBehaviour
{
    [SerializeField] private float delay;  

    private void Awake()
    {
        Destroy(gameObject, delay);
    }
}

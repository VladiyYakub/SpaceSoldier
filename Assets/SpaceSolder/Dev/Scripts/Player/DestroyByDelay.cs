using UnityEngine;

public class DestroyByDelay : MonoBehaviour
{
    [SerializeField] private float _delay;  

    private void Awake()
    {
        Destroy(gameObject, _delay);
    }
}

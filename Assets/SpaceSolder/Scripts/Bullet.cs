using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Vector3 target;
    private bool _isFlying = false;

    public void FlyToPoint(Vector3 target)
    {
        this.target = target;
        _isFlying = true;
    }

    private void Update()
    {
        if (_isFlying)
        {
            // Движение к цели
            Vector3 direction = (target - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Если пуля достигла цели, создаем эффект попадания и уничтожаем пулю
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                // Создаем эффект попадания
                // ...

                // Уничтожаем пулю
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Уничтожаем пулю при столкновении
        Destroy(gameObject);
    }
}


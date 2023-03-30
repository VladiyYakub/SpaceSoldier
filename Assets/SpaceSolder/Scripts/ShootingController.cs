using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public Button shootButton; // кнопка стрільби
    public GameObject bulletPrefab; // префаб кулі
    public Transform gunTip; // точка вистрілу зі зброї
    public float bulletSpeed = 10f; // швидкість кулі

    void Start()
    {
        // додаємо метод Shoot до обробки кліку на кнопку стрільби
        shootButton.onClick.AddListener(Shoot);
    }

    void Shoot()
    {
        // створюємо нову кулю з префабу
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);

        // визначаємо напрямок руху кулі
        Vector3 direction = gunTip.transform.up;

        // рухаємо кулю вздовж напрямку з встановленою швидкістю
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}

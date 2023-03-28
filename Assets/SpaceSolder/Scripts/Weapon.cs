using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioClip shootSound;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate;
    public float bulletSpeed;
    private float _lastFireTime;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time - _lastFireTime >= fireRate)
        {
            _lastFireTime = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        // Создаем звук выстрела
        AudioSource.PlayClipAtPoint(shootSound, transform.position);

        // Создаем пулю
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Задаем скорость пули
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.speed = bulletSpeed;

        // Направляем пулю в точку стрельбы
        bulletComponent.FlyToPoint(transform.position + transform.forward * 1000f);
    }
}

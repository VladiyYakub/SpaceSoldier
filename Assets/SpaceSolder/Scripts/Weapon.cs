using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioClip shootSound;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate;
    public float bulletSpeed;
    public float lastFireTime;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time - lastFireTime >= fireRate)
        {
            lastFireTime = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.speed = bulletSpeed;
        bulletComponent.FlyToPoint(transform.position + transform.forward * 1000f);
    }
}




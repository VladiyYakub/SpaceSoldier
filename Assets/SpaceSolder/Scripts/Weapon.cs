using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject shotEffect;
    [SerializeField] private float shotDistance;
    [Space]
    [SerializeField] private Collider[] bulletsDontCollideWith;

    public float FireRate;

    public void Shoot()
    {
        Destroy(Instantiate(shotEffect, firePoint.position, firePoint.rotation), 0.2f);
        AudioSource.PlayClipAtPoint(shootSound, firePoint.position);
        var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(firePoint.up, firePoint.forward));

        if (Physics.Raycast(firePoint.position, firePoint.forward, out var hit, shotDistance))
        {
            bullet.FlyToPoint(hit.point, Quaternion.LookRotation(hit.normal), bulletsDontCollideWith);
            Debug.DrawLine(firePoint.position, hit.point, Color.green, 1f);
        }
        else
        {
            var calculatedTarget = firePoint.forward * shotDistance;
            bullet.FlyToPoint(calculatedTarget, Quaternion.identity, bulletsDontCollideWith);
            Debug.DrawRay(firePoint.position, calculatedTarget, Color.red, 1f);
        }
    }
}

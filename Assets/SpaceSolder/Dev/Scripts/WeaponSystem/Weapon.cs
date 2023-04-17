using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _shotEffect;
    [SerializeField] private float _shotDistance;
    [Space]
    [SerializeField] private Collider[] _bulletsDontCollideWith;

    public float Range => _shotDistance;
    public float FireRate;

    private Quaternion _defaultFirePointRotation;

    private void Awake()
    {
        _defaultFirePointRotation =  _firePoint.rotation;
    }

    public void Shoot()
    {
        Destroy(Instantiate(_shotEffect, _firePoint.position, _firePoint.rotation), 0.2f);
        AudioSource.PlayClipAtPoint(_shootSound, _firePoint.position);
        var bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.LookRotation(_firePoint.up, _firePoint.forward));

        if (Physics.Raycast(_firePoint.position, _firePoint.forward, out var hit, _shotDistance))
        {
            bullet.FlyToPoint(hit.point, Quaternion.LookRotation(hit.normal), _bulletsDontCollideWith);
            Debug.DrawLine(_firePoint.position, hit.point, Color.green, 1f);
        }
        else
        {
            var calculatedTarget = _firePoint.forward * _shotDistance;
            bullet.FlyToPoint(calculatedTarget, Quaternion.identity, _bulletsDontCollideWith);
            Debug.DrawRay(_firePoint.position, calculatedTarget, Color.red, 1f);
        }
    }

    public void PointAtTarget(Transform target)
    {
        _firePoint.LookAt(target);
    }

    public void PointAtDefault()
    {
        _firePoint.rotation = _defaultFirePointRotation;
    }
}

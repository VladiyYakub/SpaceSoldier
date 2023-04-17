// Write me in Zulip what exactly this script does

using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _maxBullets = 30;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private Transform _shootPoint;

    private int _currentBullets;

    private void Start()
    {
        _currentBullets = _maxBullets;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _currentBullets > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        bullet.GetComponent<Bullet>().FlyToPoint(_shootPoint.forward * 1000f, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = _shootPoint.forward * _bulletSpeed;
        _currentBullets--;
    }

    public void AddBullets(int amount)
    {
        _currentBullets = Mathf.Min(_currentBullets + amount, _maxBullets);
    }
}

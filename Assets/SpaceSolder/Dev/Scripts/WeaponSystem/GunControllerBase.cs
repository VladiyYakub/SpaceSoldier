using UnityEngine;

public class GunControllerBase : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public Weapon CurrentWeapon => _weapon;

    private float lastShotTime;

    protected void Shoot()
    {
        if (Time.time - lastShotTime < _weapon.FireRate)
            return;

        lastShotTime = Time.time;
        _weapon.Shoot();
    }
}

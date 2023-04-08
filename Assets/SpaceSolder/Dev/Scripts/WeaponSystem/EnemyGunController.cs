using UnityEngine;

public class EnemyGunController : GunControllerBase
{
    [SerializeField] private Transform target;
    [SerializeField] private float maxShootAngle;

    private void Update()
    {
        if (target == null)
            return;

        if (Vector3.Distance(target.position, transform.position) < CurrentWeapon.Range)
        {
            var dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < maxShootAngle)
            {
                CurrentWeapon.PointAtTarget(target);
                Shoot();
            }
        }
    }
}

// TODO: add more same enemies to the game scene and describe in Zulip what kind of refactor need to be done

using UnityEngine;

public class EnemyGunController : GunControllerBase
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private float _maxShootAngle;

    private void Update()
    {
        if (_playerTarget == null)
            return;

        if (Vector3.Distance(_playerTarget.position, transform.position) < CurrentWeapon.Range)
        {
            var dirToTarget = (_playerTarget.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < _maxShootAngle)
            {
                CurrentWeapon.PointAtTarget(_playerTarget);
                Shoot();
            }
        }
    }
}

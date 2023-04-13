using UnityEngine;
using UnityEngine.UI;

public class PlayerGunController : GunControllerBase
{
    [SerializeField] private Button _shootButton;

    [SerializeField] private Transform _enemyTarget;
    [SerializeField] private float _maxAimAngle;
    [SerializeField] private float _maxAimDistance;

    private void Awake()
    {
        if (_shootButton)
            _shootButton.onClick.AddListener(Shoot);
    }


    private void Update()
    {
        if (_enemyTarget == null)
            return;

        if (Vector3.Distance(_enemyTarget.position, transform.position) < _maxAimDistance)
        {
            var dirToTarget = (_enemyTarget.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < _maxAimAngle)
            {
                transform.LookAt(_enemyTarget);
            }
        }
    }
}

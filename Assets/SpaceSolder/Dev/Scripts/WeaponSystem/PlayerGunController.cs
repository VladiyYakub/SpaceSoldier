using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunController : GunControllerBase
{
    [SerializeField] private Button _shootButton;
    [SerializeField] private float _maxAimAngle;
    [SerializeField] private float _maxAimDistance;

    [SerializeField] private EnemiesData _enemyData;

    private List<Transform> _enemies;
    private float _lastCleanupTime = 0f;

    private void Awake()
    {
        //TODO: create scriptsbleObject EnemyData, add all enemies transforms to it
        // than add this SO throw SerializeFied here
        // avoid using FIND methods


        var enemies = FindObjectsOfType<EnemyGunController>();
        _enemies = enemies.Select(enemy => enemy.transform).ToList();

        //_enemies = _enemyData.enemies;

        if (_shootButton)
            _shootButton.onClick.AddListener(Shoot);
    }

    private void Update()
    {
        if (_enemies == null || _enemies.Count == 0)
            return;

        if(Time.time - _lastCleanupTime > 1f)
        {
            _lastCleanupTime = Time.time;
            _enemies.RemoveAll(enemy => enemy == null);
        }

        var bestAngle = _maxAimAngle;
        Transform bestEnemyToAim = null;

        foreach (var enemy in _enemies)
        {
            if (!enemy)
                continue;

            if (Vector3.Distance(enemy.position, transform.position) < CurrentWeapon.Range)
            {
                var dirToTarget = (enemy.position - transform.position).normalized;
                var angle = Vector3.Angle(transform.forward, dirToTarget);

                if (angle < bestAngle)
                {
                    bestAngle = angle;
                    bestEnemyToAim = enemy;
                }
            }
        }

        if (bestEnemyToAim)
            CurrentWeapon.PointAtTarget(bestEnemyToAim);
        else
            CurrentWeapon.PointAtDefault();
    }
}

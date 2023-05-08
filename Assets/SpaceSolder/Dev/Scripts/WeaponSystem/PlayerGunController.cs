using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunController : GunControllerBase
{
    private Button _shootButton;
    private float _maxAimAngle;
    private float _maxAimDistance;

    private EnemiesData _enemyData;

    private List<Transform> _enemies;
    private float _lastCleanupTime = 0f;

    public void Init(PlayerData playerData, Button button, EnemiesData enemiesData)
    {
        _shootButton = button;
        _enemyData = enemiesData;

        _maxAimAngle = playerData.MaxAimAngle;
        _maxAimDistance = playerData.MaxAimDistance;
        _enemyData = playerData.EnemiesData; 
    }

    private void Awake()
    {
        var enemies = FindObjectsOfType<EnemyGunController>();
        _enemies = enemies.Select(enemy => enemy.transform).ToList();

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

using System.Collections.Generic;
using UnityEngine;

using static Weapon;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _shootPointDecal;    
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Collider[] dontCollideWith;

    private RaycastHit _hitInfo;
    private Vector3 _flyingDirrection;
    private bool _isFlying = false;

    private List<Collider> _dontCollideWith;


    public void FlyToPoint(RaycastHit hit, params Collider[] dontCollideWith)
    {
        _dontCollideWith = new List<Collider>();
        _dontCollideWith.AddRange(this.dontCollideWith);
        _dontCollideWith.AddRange(dontCollideWith);

        _flyingDirrection = (hit.point - transform.position).normalized;
        _hitInfo = hit;
        _isFlying = true;
    }

    private void Update()
    {
        if (!_isFlying)
            return;

        transform.position += _flyingDirrection * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var collider in _dontCollideWith)
            if (collider == other) return;

        if (other.TryGetComponent<IDamageReceiver>(out var damageReceiver))
        {
            damageReceiver.GetDamage(_damage, _hitInfo);
        }
        else
        {
            Instantiate(_shootPointDecal, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
        }

        Destroy(gameObject);
    }
}





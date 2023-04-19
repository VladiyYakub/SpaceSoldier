using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using static Weapon;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bloodEffect;
    [SerializeField] private GameObject _shootPointDecal;    
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Collider[] dontCollideWith;

    private Vector3 _target;
    private Quaternion _decalRotation;
    private bool _isFlying = false;

    private List<Collider> _dontCollideWith;

    public void FlyToPoint(Vector3 target, Quaternion decalRotation, params Collider[] dontCollideWith)
    {
        _dontCollideWith = new List<Collider>();
        _dontCollideWith.AddRange(this.dontCollideWith);
        _dontCollideWith.AddRange(dontCollideWith);

        _decalRotation = decalRotation;
        _target = target;
        _isFlying = true;
    }

    private void Update()
    {       

        if (_isFlying)
        {
            var dirrection = (_target - transform.position).normalized;
            transform.position += dirrection * _speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (var collider in _dontCollideWith)
            if (collider == other) return;

        if (other.TryGetComponent<IDamageReceiver>(out var damageReceiver))
            damageReceiver.GetDamage(_damage);

        // TODO: If I want to add some new effects on different objects?
        // I'm need to add new if statements here
        // Rewrite IDamageReceiver GetDamage() method to obtain parameter hit
        // than we can instantiate effect by this hit point in concrete damage receiver instead of do it here

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(_bloodEffect, other.ClosestPoint(transform.position), Quaternion.identity);
        }
        else
        {
            Instantiate(_shootPointDecal, _target, _decalRotation);
        }

        Destroy(gameObject);
    }

}





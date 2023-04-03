using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [SerializeField] private Button _shootButton;
    [SerializeField] private Weapon _weapon;

    private float lastShotTime;

    private void Awake()
    {
        if (_shootButton)
            _shootButton.onClick.AddListener(Shoot);
    }

    private void Shoot()
    {
        if (Time.time - lastShotTime < _weapon.FireRate)
            return;

        lastShotTime = Time.time;
        _weapon.Shoot();
    }
}

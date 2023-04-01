using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [SerializeField] private Button shootButton;
    [SerializeField] private Weapon weapon;

    private float lastShotTime;

    private void Awake()
    {
        if (shootButton)
            shootButton.onClick.AddListener(Shoot);
    }

    private void Shoot()
    {
        if (Time.time - lastShotTime < weapon.FireRate)
            return;

        lastShotTime = Time.time;

        weapon.Shoot();
    }
}

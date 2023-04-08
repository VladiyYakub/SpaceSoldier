using UnityEngine;
using UnityEngine.UI;

public class PlayerGunController : GunControllerBase
{
    [SerializeField] private Button _shootButton;

    private void Awake()
    {
        if (_shootButton)
            _shootButton.onClick.AddListener(Shoot);
    }
}

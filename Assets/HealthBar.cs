using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _barBackground;
    [SerializeField] private Image _fullHealth;
    [SerializeField] private Image _midddleHealth;
    [SerializeField] private Image _lowHealth;

    [SerializeField] private float _maxHealth;
    private void Start()
    {
        _maxHealth = 1f;
    }

    private void Update()
    {
        _maxHealth -= Time.deltaTime * 0.1f;
        _barBackground.fillAmount = _maxHealth;
    }
}

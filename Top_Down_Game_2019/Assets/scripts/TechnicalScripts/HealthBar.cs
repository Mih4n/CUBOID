using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [HideInInspector] public float MaxHealth;

    [HideInInspector] private float _health;
    [HideInInspector] private float _lerpTimer;
    [SerializeField] private float _chipSpeed = 2f;
    [SerializeField] private Image _greenField;
    [SerializeField] private Image _redField;
    [SerializeField] private Image _bloeField;

    private void Start()
    {
        _health = MaxHealth;
    }
    private void Update()
    {
        UpdateUI();
    }
    public void SetNative(float health, float maxHealth)
    {
        MaxHealth = maxHealth;
        _health = health;
    }
    private void UpdateUI()
    {
        float fillGreen = _greenField.fillAmount;
        float fillRed = _redField.fillAmount;
        float fillBloe = _bloeField.fillAmount;
        float hFraction = _health / MaxHealth;
        if (fillRed > hFraction)
        {
            _greenField.fillAmount = hFraction;
            _bloeField.fillAmount = hFraction;
            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer / _chipSpeed;
            _redField.fillAmount = Mathf.Lerp(fillRed, hFraction, percentComplete);
        }
        if (fillGreen < hFraction)
        {
            _redField.fillAmount = hFraction;
            _bloeField.fillAmount = hFraction;
            _lerpTimer += Time.deltaTime;
            float percentComplete = _lerpTimer / _chipSpeed;
            _greenField.fillAmount = Mathf.Lerp(fillGreen, _redField.fillAmount, percentComplete);
        }
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        _lerpTimer = 0f;
    }
    public void RestoreHealth(float healAmount)
    {
        _health += healAmount;
        _lerpTimer = 0f;
    }
}
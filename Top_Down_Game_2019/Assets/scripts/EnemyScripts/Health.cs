using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _hpBar;
    [SerializeField] private bool _isBossHealth;
    
    [HideInInspector] private float _health;
    [HideInInspector] private float _maxHealth;
    [HideInInspector] private Animator _animator;
    [HideInInspector] private addRoom _room;
    
    private void Awake() 
    {
        _maxHealth = GetComponent<EnemyMinde>().EnemySettings.Health;
        _health = _maxHealth;    
    }
    private void Start() 
    {
        _animator = GetComponent<Animator>();
        _room = GetComponentInParent<addRoom>();   
        _hpBar.SetActive(false);
    }
    private void Update() 
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
            _room.Enemies.Remove(gameObject);
        }    
    }
    public void TakeDamage(int damage)
    {
        _hpBar.SetActive(true);
        _health -= damage;
        if(_isBossHealth == true && _health <= _maxHealth/2)
        {
            _animator.SetBool("isInRage", true);
        }
        _healthBar.TakeDamage(damage);
    }
    public void RestoreHealth(float healAmount)
    {
        _health += healAmount;
        _healthBar.RestoreHealth(healAmount);
    }
}

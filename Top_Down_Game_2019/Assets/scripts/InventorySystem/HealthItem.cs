using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour 
{
    [SerializeField] private GameObject _healthEffect;
    [SerializeField] private int _healthBoost;
    
    [HideInInspector] private PlayerMovement _player;
    
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void Use() {
        Instantiate(_healthEffect, _player.transform.position, Quaternion.identity);
        _player.ChangeHealth(-_healthBoost);
        Destroy(gameObject);
    }
}

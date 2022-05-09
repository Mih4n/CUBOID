using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour 
{
    [SerializeField] private GameObject _item;
    
    [HideInInspector] private Transform _playerPos;

    private void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("PlayerPos").GetComponent<Transform>();
    }

    public void SpawnItem() {
        Instantiate(_item, _playerPos.position, Quaternion.identity);
    }
}

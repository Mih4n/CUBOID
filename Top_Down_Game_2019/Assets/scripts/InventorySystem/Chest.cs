using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject[] _slots;
    [SerializeField] private GameObject _chestInventory;
    [SerializeField] private GameObject _chestButton;

    [HideInInspector] private GameObject _inventory;
    [HideInInspector] private bool _isOpen;
    [HideInInspector] private bool _active = false;
    [HideInInspector] private bool _isIn = false;
    [HideInInspector] private GameObject _bag;

    private void Start() 
    {
        _bag = GameObject.FindGameObjectWithTag("Bag");
    }

    private void Update()
    {
        _isOpen = _bag.GetComponent<Bag>().IsOpen;
        if(_isIn == false || _isOpen == false)
        {
            _chestInventory.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _isIn = true;
            _chestButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _isIn = false;
            _active = false;
            _chestButton.SetActive(false);
        }
    }
    public void OpenChestInventory()
    {
        Debug.Log("Tried");
        if(_isIn == true && _isOpen == true)
        {
            _active = !_active;
            _chestInventory.SetActive(_active);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour 
{
    [SerializeField] private GameObject _itemButton;
    [SerializeField] private GameObject _effect;
    
    public bool isWeapon;

    [HideInInspector] private Inventory _inventory;
    
    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            // spawn the sun button at the first available inventory slot ! 
            

            for (int i = 0; i < _inventory.Items.Length; i++)
            {
                bool isWeaponSlot = _inventory.Slots[i].GetComponent<Slot>().IsWeaponSlot;
                bool isDropSlot = _inventory.Slots[i].GetComponent<Slot>().IsDropSlot;
                if (_inventory.Items[i] == 0 && isDropSlot != true &&((isWeaponSlot == true && isWeapon == true) || (isWeaponSlot == false && isWeapon == true) || (isWeaponSlot == false && isWeapon == false))) 
                { // check whether the slot is EMPTY
                    Instantiate(_effect, transform.position, Quaternion.identity);
                    _inventory.Items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(_itemButton, _inventory.Slots[i].transform, false); // spawn the button so that the player can interact with it
                    Destroy(gameObject);
                    break;
                }
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour 
{
    [SerializeField] private GameObject _bag;
    public bool IsOpen = true;
    
    private void OpenCloseBag() 
    {
        IsOpen = !IsOpen;
        _bag.SetActive(IsOpen);
    }
}

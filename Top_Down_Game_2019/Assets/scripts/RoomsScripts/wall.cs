using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    [SerializeField] private Transform[] _wallPoints;
    [SerializeField] private Transform[] __bigWallPoints;
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _bigWall;

    private bool spawned = false;
    
    private void OnTriggerStay2D(Collider2D other) 
    {
        Debug.Log("Enter");
        if(other.CompareTag("Block"))
        {
            if(!spawned)
            {
                foreach(Transform wallPoint in _wallPoints)
                    Instantiate(_door, wallPoint.position, Quaternion.identity); 
                foreach(Transform _bigWallPoint in __bigWallPoints)
                    Instantiate(_bigWall, _bigWallPoint.position, Quaternion.identity);  
                spawned = true;  
                Destroy(gameObject);             
            }
        }
    }
}

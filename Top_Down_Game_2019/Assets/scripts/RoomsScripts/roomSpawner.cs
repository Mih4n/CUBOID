using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    public Direction _direction;

    public enum Direction
    {
        Top,
        Down,
        Left,
        Right,
        None
    }
    
    [HideInInspector] private roomVariants _variants;
    [HideInInspector] private int _rand;
    [HideInInspector] private bool _spawned = false;
    [HideInInspector] private float _WaitTime = 3f;

    private void Start()
    {
        _variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomVariants>();
        Destroy(gameObject, _WaitTime);
        Invoke("Spawn", 0.2f);
    }
    private void Spawn()
    {
        if(_spawned == false)
        {
            if(_direction == Direction.Top)
            {
                _rand = Random.Range(0, _variants.TopRooms.Length);
                Instantiate(_variants.TopRooms[_rand], transform.position, _variants.TopRooms[_rand].transform.rotation);
            }else if(_direction == Direction.Down)
            {
                _rand = Random.Range(0, _variants.DownRooms.Length);
                Instantiate(_variants.DownRooms[_rand], transform.position, _variants.DownRooms[_rand].transform.rotation);
            }else if(_direction == Direction.Right)
            {
                _rand = Random.Range(0, _variants.RightRooms.Length);
                Instantiate(_variants.RightRooms[_rand], transform.position, _variants.RightRooms[_rand].transform.rotation);
            }else if(_direction == Direction.Left)
            {
                _rand = Random.Range(0, _variants.LeftRooms.Length);
                Instantiate(_variants.LeftRooms[_rand], transform.position, _variants.LeftRooms[_rand].transform.rotation);
            }
            _spawned = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("RoomPoint"))
            if(other.GetComponent<roomSpawner>()._spawned == false && _spawned == false)
            {
                Instantiate(_variants.ColosedRoom, transform.position, _variants.ColosedRoom.transform.rotation);
                Destroy(gameObject);
            }
            _spawned = true;
    }
}

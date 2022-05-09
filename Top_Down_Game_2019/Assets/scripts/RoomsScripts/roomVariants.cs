using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomVariants : MonoBehaviour
{
	[SerializeField] private GameObject _boss;
	
    public GameObject[] TopRooms;
    public GameObject[] DownRooms;
    public GameObject[] RightRooms;
    public GameObject[] LeftRooms;
    public GameObject ColosedRoom;
    public List<GameObject> Rooms;
	public float WaitTime;

	[HideInInspector] private bool _spawnedBoss;

	private void Update(){

		if(WaitTime <= 0 && _spawnedBoss == false){
			for (int i = 0; i < Rooms.Count; i++) {
				if(i == Rooms.Count-1){
					Instantiate(_boss, Rooms[i].transform.position, Quaternion.identity);
					_spawnedBoss = true;
				}
			}
		} else {
			WaitTime -= Time.deltaTime;
		}
	}
}

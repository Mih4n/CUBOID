using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addRoom : MonoBehaviour
{
	[Header("Walls and lights")]
	[SerializeField] private GameObject[] _walls;
	[SerializeField] private GameObject[] _lights;

	[Header("Enemies")]
	[SerializeField] private GameObject[] _enemyTypes;
	[SerializeField] private Transform[] _enemySpawners;
	[SerializeField] [Range(0, 100)] private int _enemySpawnChance;

	[HideInInspector] public List<GameObject> Enemies;
	[HideInInspector] private roomVariants _variants;
	[HideInInspector] private bool _spawned = false;
	[HideInInspector] private bool _wallsDestroyed;
	[HideInInspector] public float _waitTime = 1f;
	[HideInInspector] private roomVariants _templates;

	private void Start()
	{
		_variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomVariants>();
		_templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomVariants>();
		_templates.Rooms.Add(this.gameObject);
		foreach(GameObject wall in _walls)
		{
			wall.SetActive(false);
		}
		foreach(GameObject light in _lights)
		{
			light.SetActive(false);
		}
	}
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.CompareTag("Player"))
			foreach(GameObject light in _lights)
			{
				light.SetActive(true);
			}
		if(other.CompareTag("Player") && !_spawned)
		{
			foreach(GameObject wall in _walls)
			{
				wall.SetActive(true);
			}
			foreach(Transform spawner in _enemySpawners)
			{
				int rand = Random.Range(0, 101);
				if(rand < _enemySpawnChance)
				{
					GameObject _enemyType = _enemyTypes[Random.Range(0, _enemyTypes.Length)];
					GameObject _enemy = Instantiate(_enemyType, spawner.position, Quaternion.identity) as GameObject;
					_enemy.transform.parent = transform;
					Enemies.Add(_enemy);
					Debug.Log("Hi1");
				}
			}
			_spawned = true;
			StartCoroutine(CheckEnemies());
		}
	}
	private void OnTriggerExit2D(Collider2D other) 
	{
		if(other.CompareTag("Player"))
			foreach(GameObject light in _lights)
			{
				light.SetActive(false);
			}
		
	}
	IEnumerator CheckEnemies()
	{
		yield return new WaitForSeconds(1f);
		yield return new WaitUntil(() => Enemies.Count == 0);
		DestroyWalls();
	}
	public void DestroyWalls()
	{
		Debug.Log("Hi3");
		foreach(GameObject wall in _walls)
		{
			if(wall != null && wall.transform.childCount != 0)
			{
				Destroy(wall);
				Debug.Log("Hi2");
			}
		}
		_wallsDestroyed = true;
	}
}
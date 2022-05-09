using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPreferences", menuName = "Preferences/newPlayerPreferences", order = 0)]
public class PlayerPreferences : ScriptableObject 
{
    [SerializeField] private float _speed;
    public float Speed
    {
        get{ return _speed; }
        set
        {

        }
    }
    [SerializeField] private int _health;
    public int Health
    {
        get { return _health; }
        set
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Preferences/newEnemyPreferences", order = 0)]
public class EnemyPreferences : ScriptableObject
{
    [SerializeField] private SckinsDatabase _skins;
    public SckinsDatabase Skins
    {
        get { return _skins;}
        set
        {

        }
    }
    [SerializeField] private float _health;
    public float Health
    {
        get { return _health;}
        set
        {

        }
    }
    [Header("Enemy settings")]
    [SerializeField] private int _damage;
    public int Damage
    {
        get { return _damage; }
        set
        {

        }
    }
    [SerializeField] private Vector3 _offset;
    public Vector3 Offset
    {
        get { return _offset; }
        set
        {
            
        }
    }
    [Header("Enemy with gun settings")]
    [SerializeField] private float _radius;
    public float Radius
    {
        get { return _radius; }
        set
        {
            
        }
    }
}

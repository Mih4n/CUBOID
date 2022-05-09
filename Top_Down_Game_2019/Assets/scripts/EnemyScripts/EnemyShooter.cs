using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : EnemyMinde
{
    [SerializeField] private float _radius;
    
    [HideInInspector] private float _angle;
    [HideInInspector] private Vector2 _circleMove;

    private void Start() 
    {
        OnStart();
        _radius = EnemySettings.Radius;
    }
    private void Update() 
    {
        if(Player.transform.position.x > transform.position.x && !FacingRight)
        {
            Flip();
        }
        if(Player.transform.position.x < transform.position.x && FacingRight)
        {
            Flip();
        }
        _angle += Time.deltaTime;
        var x = Player.transform.position.x + Mathf.Cos (_angle) * _radius;
        var y = Player.transform.position.y + Mathf.Sin (_angle) * _radius;
        _circleMove = new Vector2(x, y);
        Agent.SetDestination(_circleMove);
    }
}

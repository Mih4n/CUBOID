
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : EnemyMinde
{
    [HideInInspector] private int _damage;
    [HideInInspector] private Vector3 _offset;
    [HideInInspector] private Vector2 _playerPosition;

    private void Start() 
    {
        _damage = EnemySettings.Damage;
        _offset = EnemySettings.Offset;
        OnStart();
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
        _playerPosition = new Vector2(Player.transform.position.x + _offset.x, Player.transform.position.y + _offset.y);
        Agent.SetDestination(_playerPosition);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Anim.SetBool("isAttack", true);
        } 
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Anim.SetBool("isAttack", false);
        } 
    }
    private void OnEnemyAttack()
    {
        Player.TakeDamage(_damage);
    }
}

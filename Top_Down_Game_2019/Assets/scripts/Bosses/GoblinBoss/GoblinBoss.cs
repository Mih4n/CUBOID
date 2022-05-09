using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBoss : EnemyMinde
{
    [SerializeField] private int _damage;

    public Vector3 Offset;
    public float Radius;

    private void Awake() 
    {
        OnStart();
    }
    private void Start() 
    {
        Anim = GetComponent<Animator>();
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
    public void OnEnemyAttack()
    {
        Player.ChangeHealth(_damage);
    }
}

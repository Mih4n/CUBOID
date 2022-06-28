using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _distance;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _whatIsSolid;
    [SerializeField] private GameObject _destroyEffect;
    [SerializeField] private bool _isEnemy;
    private void Start()
    {
        Invoke("DestroyProjectile", _lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, _distance, _whatIsSolid);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy") && !_isEnemy) {
                hitInfo.collider.GetComponent<Health>().TakeDamage(_damage);
            }
            if (hitInfo.collider.CompareTag("Player") && _isEnemy) {
                hitInfo.collider.GetComponent<PlayerMovement>().TakeDamage(_damage);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void DestroyProjectile() {
        Destroy(gameObject);
    }
}
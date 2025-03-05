using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Stats")]
    [SerializeField] private float BulletSpeed = 5.0f;
    [SerializeField] private int BulletDmg = 1;

    private Transform Target;

    public void SetTarget(Transform _Target)
    {
        Target = _Target;
    }

    private void FixedUpdate()
    {
        if (!Target) return;
        
        Vector2 direction = (Target.position - transform.position).normalized;
        rb.velocity = direction * BulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(BulletDmg);
        Destroy(gameObject);
    }

}

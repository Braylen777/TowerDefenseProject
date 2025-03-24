using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Stats")]
    [SerializeField] private float BulletSpeed = 5.0f;
    [SerializeField] private int BulletDmg = 1;

    private Transform Target;
    private Vector3 point;
    public AudioClip bulletSound;
    public void SetTarget(Transform _Target)
    {
        Target = _Target;
    }

    private void FixedUpdate()
    {
        if (!Target) return;

        Vector2 direction = (Target.position - transform.position).normalized;
        rb.velocity = direction * BulletSpeed;

        Vector3 targ = Target.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(BulletDmg);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(bulletSound, point);
    }

}

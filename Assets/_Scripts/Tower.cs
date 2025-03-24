using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform TowerRotationPoint;
    [SerializeField] private LayerMask EnemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePoint;

    [Header("Stats")]
    [SerializeField] private float TargetingRange = 5.0f;
    [SerializeField] private float rotationSpeed = 200.0f;
    [SerializeField] private float BPS = 1.0f; //BulletsPerSecond

    private Transform Target;
    private float TUF; //Time Until Fire

    private void Update()
    {
        if (Target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetInRange())
        {
            Target = null;
        } 
        else
        {
            TUF += Time.deltaTime;
            if (TUF >= 1f / BPS)
            {
                Shoot();
                TUF = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, FirePoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(Target);
        
        //Debug.Log("Shots Fired!");
    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, TargetingRange, (Vector2)transform.position, 0f, EnemyMask);

        if (hits.Length > 0)
        {
            Target = hits[0].transform;
        }
    }

    private bool CheckTargetInRange()
    {
        return Vector2.Distance(Target.position, transform.position) <= TargetingRange;
    }
    
    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x) * Mathf.Rad2Deg + -90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        TowerRotationPoint.rotation = Quaternion.RotateTowards(TowerRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


   // private void OnDrawGizmosSelected()
    //{
     //   Handles.color = Color.cyan;
      //  Handles.DrawWireDisc(transform.position, transform.forward, TargetingRange);
    //}




}

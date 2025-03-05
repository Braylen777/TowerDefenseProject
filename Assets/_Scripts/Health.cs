using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int HP = 2; //Health Points

    public void TakeDamage(int dmg) //Damage
    {
        HP -= dmg;
        if (HP <= 0)
        {
            EnemySpawner.onEnemyDeath.Invoke();
            Destroy(gameObject);
        }
    }

}

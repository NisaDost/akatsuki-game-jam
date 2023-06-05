using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{

    public float maxHealth = 100f;
    private float currentHealth;
    public float damage = 10f;

    void Start()
    {
        currentHealth = maxHealth;

    }


    public void TakeDamage(float damageAmount)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0f)
            {
                Die();
            }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(damage);
            Debug.Log("enemy hurt");
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(damage);
            Debug.Log("oof");
        }
        

    }

    private void Die()
    {
        //öl
    }
}

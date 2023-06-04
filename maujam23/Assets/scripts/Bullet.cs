using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage = 10f;
    private Vector3 direction;
    public float speed = 10f;

    public void ShootBullet(Vector3 dir)
    {
        direction = dir;

    }

    public void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //DESTROY
            player_health playerHealth = other.GetComponent<player_health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    
        else if (other.CompareTag("Ground")){
            Destroy(gameObject);

        }
        
    }
}

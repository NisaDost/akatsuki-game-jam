using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Transform player;
    public float shootingRange = 10f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int bulletDamage = 10;
    public float shootingCooldown = 2f;

    
    private bool canShoot = true;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= shootingRange && canShoot)
        {
            Shoot();
            canShoot = false;
            Invoke(nameof(ResetShooting), shootingCooldown);
        }
    }

    void Shoot()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = direction * bulletSpeed;
        bullet.GetComponent<Bullet>().damage = bulletDamage;
    }

    void ResetShooting()
    {
        canShoot = true;
    }

    

}

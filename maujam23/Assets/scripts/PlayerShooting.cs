using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public int bulletDamage = 10;
    public float shootingCooldown = 0.5f;

    private bool canShoot = true;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
            Debug.Log("ffffffffffffff");
            canShoot = false;
            Invoke(nameof(ResetShooting), shootingCooldown);
        }
    }

    private void Shoot()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 spawnPosition = bulletSpawnPoint.position;

        Vector2 direction = mousePosition - spawnPosition;
        direction.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = direction * bulletSpeed;
        bullet.GetComponent<Bullet>().damage = bulletDamage;
    }

    private void ResetShooting()
    {
        canShoot = true;
    }
}

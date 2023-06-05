using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject pbulletPrefab;
    public Transform pbulletSpawnPoint;
    public float pbulletSpeed = 10f;
    public float pbulletDamage =10f;
    public float pshootingCooldown = 0.5f;

 

    private bool canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            Shoot();
            Debug.Log("ffffffffffffff");
            canShoot = false;
            Invoke(nameof(ResetShooting), pshootingCooldown);
        }
    }

    private void Shoot()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 spawnPosition = pbulletSpawnPoint.position;

        Vector2 direction = mousePosition - spawnPosition;
        direction.Normalize();

        GameObject pbullet = Instantiate(pbulletPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D pbulletRB = pbullet.GetComponent<Rigidbody2D>();
        pbulletRB.velocity = direction * pbulletSpeed;

        pbullet.GetComponent<playerbullet>().damage = pbulletDamage;
    }

    private void ResetShooting()
    {
        canShoot = true;
    }
}

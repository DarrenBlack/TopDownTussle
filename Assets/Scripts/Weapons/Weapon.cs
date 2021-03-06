﻿using UnityEngine;
using System.Collections;
using EZCameraShake;

public class Weapon : MonoBehaviour
{
    public float fireDelay;
    public Bullet bulletType;
    public Transform firePoint;
    public FiringType fireType;
    public int noInBurst;

    private float shotCounter;
    private bool canShoot;

    void Update()
    {
        shotCounter -= Time.deltaTime;
    }

    public void Fire()
    {
        if (shotCounter <= 0 && canShoot)
        {
            switch (fireType)
            {
                case (FiringType.Automatic):
                    ShootBullet();
                    break;
                case (FiringType.Burst):
                    StartCoroutine(FireBurst());
                    canShoot = false;
                    break;
                case (FiringType.SemiAutomatic):
                    ShootBullet();
                    canShoot = false;
                    break;                                        
            }
            shotCounter = fireDelay;
        }        
    }

    IEnumerator FireBurst()
    {
        for (int i = 0; i < noInBurst; i++)
        {
            ShootBullet();
            yield return new WaitForSeconds(fireDelay);
        }
    }

    void ShootBullet()
    {
        Bullet newBullet = Instantiate(bulletType, firePoint.transform.position, firePoint.rotation) as Bullet;
        CameraShaker.Instance.ShakeOnce(1f, 2f, 0.1f, 1f);
    }

    public void TriggerLifted()
    {
        canShoot = true;
    }

    public void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

}

public enum FiringType
{
    Automatic,
    SemiAutomatic,
    Burst
};


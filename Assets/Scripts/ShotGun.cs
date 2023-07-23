using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : BaseGun
{
    public GameObject bulletPreFab;
    public Transform firePoint;
    public float fireForce = 20f;
    public int numBullets = 5; // Number of bullets to shoot in the shotgun spread
    public float spreadAngle = 15f; // Angle of the shotgun spread


    public override void Fire()
    {
        for (int i = 0; i < numBullets; i++)
        {
            // Calculate the rotation for the current bullet
            float bulletAngle = firePoint.eulerAngles.z - (spreadAngle / 2) + (i * spreadAngle / (numBullets - 1));
            Quaternion bulletRotation = Quaternion.Euler(0f, 0f, bulletAngle);

            GameObject bullet = Instantiate(bulletPreFab, firePoint.position, bulletRotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * fireForce, ForceMode2D.Impulse);
        }
    }
}

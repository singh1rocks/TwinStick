using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
    private float nextFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isFiring && Time.time > nextFire)
        {
            nextFire = Time.time + timeBetweenShots;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
		
	}
}
